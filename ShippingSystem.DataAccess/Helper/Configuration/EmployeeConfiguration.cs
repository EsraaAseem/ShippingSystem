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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        { 
            builder.ToTable("Employees");
           // builder.HasOne(x => x.employeeRole).WithMany().HasForeignKey(x=>x.RoleId).IsRequired();
            builder.Property(x => x.Salary).IsRequired();
            //builder.Property(x => x.JobStart).IsRequired();
        }
    }
}
