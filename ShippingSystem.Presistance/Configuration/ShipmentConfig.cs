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
    internal class ShipmentConfig : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasOne(b => b.BackUp).WithMany().HasForeignKey(b => b.BackupId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.ShippmentStatus).WithMany().HasForeignKey(b => b.ShipmentStatusId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.City).WithMany().HasForeignKey(b => b.CityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.ShipmentType).WithMany().HasForeignKey(b => b.ShipmentTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Shipping).WithMany().HasForeignKey(b => b.ShippingId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Client).WithMany().HasForeignKey(b => b.ClientId).OnDelete(DeleteBehavior.Restrict);
            builder.OwnsMany(r => r.Products);
            builder.OwnsOne(r => r.Reciver);


        }
    }
}
