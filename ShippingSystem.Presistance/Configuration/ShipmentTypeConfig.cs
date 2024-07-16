using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShippingSystem.Domain.Models;

namespace ShippingSystem.Presistance.Configuration
{
    internal class ShipmentTypeConfig : IEntityTypeConfiguration<ShipmentType>
    {
        public void Configure(EntityTypeBuilder<ShipmentType> builder)
        {
            builder.HasData
                (
                new ShipmentType(1,"Normal",7,20),
               new ShipmentType(2, "In4Days", 4, 30)

                );
        }
    }
}
