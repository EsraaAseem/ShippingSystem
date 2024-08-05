﻿using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesInvoices
{
    public record PaidDeliveryFeesInvoicesCommand(string representativeId) : ICommand<BaseResponse>;
  
}
