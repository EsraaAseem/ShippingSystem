using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Representatives.Commands.UpdateRepresentative
{
    public record UpdateRepresentativeCommand(string representativeId, string firstName, string lastName, string? governorate,
            string? branchName, string? phoneNumber, string? email, string userName, string city,
            string address) :ICommand<BaseResponse>;
}
