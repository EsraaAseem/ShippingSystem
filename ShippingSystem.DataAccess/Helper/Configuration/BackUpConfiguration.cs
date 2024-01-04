using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShippingSystem.Model.BaseModel;

namespace ShippingSystem.DataAccess.Helper.Configuration
{
    public class BackupConfiguration : IEntityTypeConfiguration<BackUp>
    {
        public void Configure(EntityTypeBuilder<BackUp> builder)
        {
            builder.HasKey(x => x.BackupId);
            builder.HasOne(x => x.Courier).WithMany().HasForeignKey(x => x.CourierId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Client).WithMany().HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Vehicle).WithMany().HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne(x => x.backupStatus).WithMany().HasForeignKey(x => x.backupStatusId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
