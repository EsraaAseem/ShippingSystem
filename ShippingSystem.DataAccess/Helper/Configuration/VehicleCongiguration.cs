using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShippingSystem.Model.BaseModel;

namespace ShippingSystem.DataAccess.Helper.Configuration
{
    public class VehicleCongiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.HasData(
                new Vehicle
                {
                    Id = 1,
                    Name="Car",
                    Description="for middle Shipping"
                },
                new Vehicle
                {
                    Id = 2,
                    Name="Truck",
                    Description="for Heavy Shipping"

                },
                new Vehicle
                {
                    Id=3,
                    Name="MotorCycle",
                    Description="for Small Size"
                }
                );
        }
    }
}
