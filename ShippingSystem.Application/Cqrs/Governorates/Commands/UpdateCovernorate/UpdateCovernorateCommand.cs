using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Governorates.Commands.UpdateCovernorate
{
  public record UpdateCovernorateCommand(Guid id,string name):ICommand<BaseResponse>;
}
