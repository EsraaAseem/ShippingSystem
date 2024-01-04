using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Model.BaseModel;

namespace ShippingSystem.DataAccess.Helper.Configuration
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(x => x.ShipmentId);
            builder.HasOne(x => x.Shipping).WithMany().HasForeignKey(x => x.ShippingId).OnDelete(DeleteBehavior.NoAction);
           builder.HasOne(x => x.Area).WithMany().HasForeignKey(x => x.AreaId).OnDelete(DeleteBehavior.NoAction);
           builder.HasOne(x => x.ShippingStatus).WithMany().HasForeignKey(x => x.ShipmentStatusId).OnDelete(DeleteBehavior.NoAction);
           builder.HasOne(x => x.BackUp).WithMany().HasForeignKey(x => x.BackupId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
