using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShippingSystem.Model.BaseModel;


namespace ShippingSystem.DataAccess.Helper.Configuration
{
    public class CourierConfiguration:IEntityTypeConfiguration<Courier>
    {
        public void Configure(EntityTypeBuilder<Courier> builder)
        {
            builder.ToTable("Couriers");
           /* builder.Property(x => x.Salary).IsRequired();
            builder.Property(x => x.JobStart).IsRequired();*/
            
        }
    }
}
