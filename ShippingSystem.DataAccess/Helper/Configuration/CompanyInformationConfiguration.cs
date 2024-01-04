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
    public class CompanyInformationConfiguration : IEntityTypeConfiguration<CompanyInformation>
    {
        public void Configure(EntityTypeBuilder<CompanyInformation> builder)
        {
            builder.HasKey(x => x.CompanyId);
            builder.HasData(
                new CompanyInformation
                {
                    CompanyId = 1,
                    CompanyName="JwelleyForShipping",
                    City="Cairo",
                    Address="Naser City",
                    CompanyPhone="0117844587",
                    Logo= "https://img.freepik.com/premium-vector/fast-shipping-logo_10250-3101.jpg?w=740",
                    Email="JwelleryCompany@gmail.com",
                   
                }
                );

        }
    }
}
