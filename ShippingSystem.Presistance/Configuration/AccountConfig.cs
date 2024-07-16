using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Models;

namespace ShippingSystem.Presistance.Configuration
{
    internal class AccountConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.OwnsMany(r => r.RefreshTokens);

        }
    }
}
