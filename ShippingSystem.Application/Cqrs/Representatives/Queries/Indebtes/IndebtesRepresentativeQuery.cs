﻿using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Representatives.Queries.Indebtes
{
    public record IndebtesRepresentativeQuery(string representativeId):IQuery<BaseResponse>;
}
