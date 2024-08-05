using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Models;

namespace ShippingSystem.Presistance.Configuration
{
    internal class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne(b => b.Client).WithMany().HasForeignKey(b => b.ClientId).
                OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Representative).WithMany().HasForeignKey(b => b.RepresentativeId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
