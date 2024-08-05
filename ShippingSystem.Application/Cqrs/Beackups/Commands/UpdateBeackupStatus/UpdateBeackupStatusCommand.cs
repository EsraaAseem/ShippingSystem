using ShippingSystem.Application.Abstractions;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Beackups.Commands.UpdateBeackupStatus
{
    public record UpdateBeackupStatusCommand(Guid beackupId,Beackupstatus status ):ICommand<BaseResponse>;
}
