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
    public class BackupStatusConfiguration : IEntityTypeConfiguration<BackupStatus>
    {
        public void Configure(EntityTypeBuilder<BackupStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StatusName).IsRequired();
            builder.HasData(
                new BackupStatus
                {
                    Id =1,
                    StatusName = "Waiting"
                },
                new BackupStatus
                {
                    Id =2,
                    StatusName = "NotifiedCourier"
                },
                new BackupStatus
                {
                    Id =3,
                    StatusName = "Processing"
                },
                new BackupStatus
                {
                    Id =4,
                    StatusName ="Completed"
                },
                new BackupStatus
                {
                    Id = 5,
                    StatusName = "Rejectd"
                });
        }
    }
}
