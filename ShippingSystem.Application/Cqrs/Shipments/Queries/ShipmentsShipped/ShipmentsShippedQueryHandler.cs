using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Clients.Queries.ShipedOrders;
using ShippingSystem.Application.Cqrs.Clients.Responses;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Shipments.Queries.ShipmentsShipped
{
    internal class ShipmentsShippedQueryHandler : IQueryHandler<ShipmentsShippedQuery, BaseResponse>
    {
        private readonly IShipmentServiceQuery _shipmentService;
        public ShipmentsShippedQueryHandler(IShipmentServiceQuery shipmentService)
        {
            _shipmentService = shipmentService;
        }

        public async Task<BaseResponse> Handle(ShipmentsShippedQuery request, CancellationToken cancellationToken)
        {
            List<Shipment> shipments = await _shipmentService.GetShipmentsShipped();

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
                Indebtedness = ship.NetAccount() < 0 ? Math.Abs(ship.NetAccount()) : 0,
                indebtes = ship.NetAccount() > 0 ? Math.Abs(ship.NetAccount()) : 0,

            }).ToList();
            return await BaseResponse.SuccessResponseWithDataAsync(ships);
        }
    }
}
