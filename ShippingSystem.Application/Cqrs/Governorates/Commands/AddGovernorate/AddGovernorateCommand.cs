using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Governorates.Commands.AddGovernorate
{
    public record AddGovernorateCommand(string name):ICommand<BaseResponse>;
   
}
