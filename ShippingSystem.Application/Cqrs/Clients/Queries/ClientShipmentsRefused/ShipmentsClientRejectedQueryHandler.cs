using MapsterMapper;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRequests;
using ShippingSystem.Application.Cqrs.Clients.Responses;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShippingSystem.Domain.Enums;

namespace ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRefused
{
    internal class ShipmentsClientRejectedQueryHandler : IQueryHandler<ShipmentsClientRejectedQuery, BaseResponse>
    {

        private readonly IShipmentServiceQuery _shipmentService;
        private readonly IMapper _mapper;
        public ShipmentsClientRejectedQueryHandler(IShipmentServiceQuery shipmentService, IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(ShipmentsClientRejectedQuery request, CancellationToken cancellationToken)
        {
            var shipments = await _shipmentService.GetClientShipmentsRejected(request.clientId);

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
                Indebtedness =Math.Abs( ship.ShippingPrice())
            }).ToList();
            return await BaseResponse.SuccessResponseWithDataAsync(ships);

        }
    }
}
