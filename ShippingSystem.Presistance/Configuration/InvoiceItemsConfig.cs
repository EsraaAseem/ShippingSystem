using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Models;

namespace ShippingSystem.Presistance.Configuration
{
    public class InvoiceItemsConfig : IEntityTypeConfiguration<InvoiceItems>
    {
        public void Configure(EntityTypeBuilder<InvoiceItems> builder)
        {
            builder.HasOne(b => b.Invoice).WithMany().HasForeignKey(b => b.InvoiceId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
