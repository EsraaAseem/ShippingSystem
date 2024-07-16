using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle
{
    public record AddVehicleCommand(string name,string description):ICommand<BaseResponse>;
}
