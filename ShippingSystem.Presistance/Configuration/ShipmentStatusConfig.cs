using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Models;
using ShippingSystem.Domain.Enums;

namespace ShippingSystem.Presistance.Configuration
{
    public class ShipmentStatusConfig : IEntityTypeConfiguration<ShipmentStatus>
    {
        public void Configure(EntityTypeBuilder<ShipmentStatus> builder)
        {
        
           builder.HasData(
                new ShipmentStatus(Guid.Parse("1704F7D4-2929-41A1-92CE-D1129B151CA0"),
                ShipmentStatuses.UnConfirmed, "Reciver reject the shipment")
                ) ;
            
        }
    }
}
