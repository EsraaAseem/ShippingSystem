﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Domain.Helper
{
    public class AggregateRoot : Entity
    {
        public AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
