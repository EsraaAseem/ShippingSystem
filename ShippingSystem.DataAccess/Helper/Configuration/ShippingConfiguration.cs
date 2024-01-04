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
    public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.HasKey(x => x.ShippingId);
            
            builder.HasOne(x => x.Courier).WithMany().HasForeignKey(x => x.CourierId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Vehicle).WithMany().HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
