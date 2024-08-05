using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Vehicles.Quries.GetVehicles
{
    internal class VehiclesQueryHandler : IQueryHandler<VehiclesQuery, BaseResponse>
    {
        private readonly IVehicleServiceQuery _vehicleService;
        public VehiclesQueryHandler( IVehicleServiceQuery vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<BaseResponse> Handle(VehiclesQuery request, CancellationToken cancellationToken)
        {
            return await BaseResponse.SuccessResponseWithDataAsync(await _vehicleService.GetVehicles());
        }
    }
}
