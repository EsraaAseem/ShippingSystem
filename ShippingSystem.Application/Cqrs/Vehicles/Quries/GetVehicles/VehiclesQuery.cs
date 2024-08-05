using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Vehicles.Quries.GetVehicles
{
    public record VehiclesQuery():IQuery<BaseResponse>;
}
