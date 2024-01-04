using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShippingSystem.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DataAccess.Helper.Configuration
{
    public class EmployeeRoleConfiguration//:IEntityTypeConfiguration<EmployeeRole>
    {
       /* public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.HasKey("RoleId");
            //builder.Property(x=>x.RoleId).IsRequired();
            builder.Property(x=>x.RoleName).IsRequired();
        }*/
    }
}
