using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Presistance.Configuration
{
    internal class BeackupConfig : IEntityTypeConfiguration<Beackup>
    {
        public void Configure(EntityTypeBuilder<Beackup> builder)
        {
            builder.HasOne(b=>b.Client).WithMany().HasForeignKey(b=>b.ClientId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Representative).WithMany().HasForeignKey(b => b.RepresentativeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Vehicle).WithMany().HasForeignKey(b => b.VehicleId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
