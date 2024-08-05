using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.Clients.Responses;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRequests
{
    internal class ShipmentsClientRequestsQueryHandler:IQueryHandler<ShipmentsClientRequestsQuery,BaseResponse>
    {

        private readonly IShipmentServiceQuery _shipmentService;
        private readonly IMapper _mapper;
        public ShipmentsClientRequestsQueryHandler(IShipmentServiceQuery shipmentService,IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(ShipmentsClientRequestsQuery request, CancellationToken cancellationToken)
        {
           var shipments = await _shipmentService.GetClientShipmentsRequests(request.clientId);
           var ships = _mapper.Map<List<ShipmentsClientsResponse>>(shipments);
           return await BaseResponse.SuccessResponseWithDataAsync(ships);

        }
    }
}
/*
  var shipments = _shipmentService.GetClientShipmentsRequests(request.clientId).Select(s => new ShipmentsClientsResponse
            {
                TrackingNumber = s.TrackingNumber,
                ShipmentType=s.ShipmentType.Name,
                ShippmentStatus=s.ShippmentStatus.ShipmentStatusName,
                TotalPrice=s.NetAccount,
                Reciver=new ReciverClientResponse
                {
                    Email=s.Reciver.Email,
                    City=s.Reciver.City,
                    Phone=s.Reciver.Phone,
                    StreetAddress=s.Reciver.StreetAddress,
                    Name=s.Reciver.Name,
                },
                Products= s.Products.Select(s=> new ProductCLientResponse
                {
                    ProductName=s.ProductName,
                    ProductPrice=s.ProductPrice,
                    Amount=s.Amount,
                    

                }).ToList(),
                QrCodeUrl=s.QrCodeUrl,

            });
 */