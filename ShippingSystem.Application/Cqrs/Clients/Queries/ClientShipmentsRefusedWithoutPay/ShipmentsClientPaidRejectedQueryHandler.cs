using MapsterMapper;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRefused;
using ShippingSystem.Application.Cqrs.Clients.Responses;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRefusedWithoutPay
{
    internal class ShipmentsClientPaidRejectedQueryHandler : IQueryHandler<ShipmentsPaidRejectedQuery, BaseResponse>
    {

        private readonly IShipmentServiceQuery _shipmentService;
        private readonly IMapper _mapper;
        public ShipmentsClientPaidRejectedQueryHandler(IShipmentServiceQuery shipmentService, IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(ShipmentsPaidRejectedQuery request, CancellationToken cancellationToken)
        {
            var shipments = await _shipmentService.GetClientShipmentsRejectedWithPaid(request.clientId);

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
            }).ToList();
            return await BaseResponse.SuccessResponseWithDataAsync(ships);

        }
    }
}
