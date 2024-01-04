using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Model.BaseModel;

namespace ShippingSystem.DataAccess.Helper.Configuration
{
    public class ShipmentStatusConfiguration : IEntityTypeConfiguration<ShipmentStatus>
    {
        public void Configure(EntityTypeBuilder<ShipmentStatus> builder)
        {
            builder.HasKey(x => x.ShipmentStatusId);
        }
    }
}
