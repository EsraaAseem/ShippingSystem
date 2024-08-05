using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.Clients.Responses;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Clients.Queries.ShipedOrders
{
    internal class ShippedOrderQueryHandler : IQueryHandler<ShippedOrderQuery, BaseResponse>
    {
        private readonly IShipmentServiceQuery _shipmentService;
        public ShippedOrderQueryHandler( IShipmentServiceQuery shipmentService)
        {
            _shipmentService = shipmentService;
        }

        public async Task<BaseResponse> Handle(ShippedOrderQuery request, CancellationToken cancellationToken)
        {
            List<Shipment> shipments = await _shipmentService.GetClientShipmentsShipped(request.clientId);

            double netaccount = 0;
            var ships = shipments.Select(ship => new ShipmentsClientsResponse
            {
                TrackingNumber = ship.TrackingNumber,
                Products = ship.Products.Select(prod => new ProductCLientResponse
                {
                    ProductName = prod.ProductName,
                    Amount = prod.NotRecivedAmount,
                    ProductPrice = prod.ProductPrice
                }).ToList(),
                Reciver = new ReciverClientResponse
                {
                    Name = ship.Reciver.Name,
                    City = ship.Reciver.City,
                    StreetAddress = ship.Reciver.StreetAddress,
                    Email = ship.Reciver.Email,
                    Phone = ship.Reciver.Phone
                },
                ShipmentType = ship.ShipmentType.Name,
                ProccedDate = ship.ProccedDate,
                ShippmentStatus = ShipmentStatuses.Returned.ToString(),
                QrCodeUrl = ship.QrCodeUrl,
                TotalPrice = ship.TotalPrice,
                Indebtedness = ship.NetAccount() <0?Math.Abs(ship.NetAccount()) :0,
                indebtes = ship.NetAccount() > 0 ? Math.Abs(ship.NetAccount()) : 0,

            }).ToList();
            return await BaseResponse.SuccessResponseWithDataAsync(ships);
        }
    }
}
