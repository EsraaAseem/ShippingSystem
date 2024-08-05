using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Models;


namespace ShippingSystem.Presistance.Configuration
{
    internal class DeliveryFeesConfig : IEntityTypeConfiguration<DeliveryFees>
    {
        public void Configure(EntityTypeBuilder<DeliveryFees> builder)
        {
            builder.HasOne(b => b.Representative).WithMany().HasForeignKey(b => b.RepresentativeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
