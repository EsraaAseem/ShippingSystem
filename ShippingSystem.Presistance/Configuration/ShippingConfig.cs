using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Models;
namespace ShippingSystem.Presistance.Configuration
{
    public class ShippingConfig : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.HasOne(b => b.Representative).WithMany().HasForeignKey(b => b.RepresentativeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Vehicle).WithMany().HasForeignKey(b => b.VehicleId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
