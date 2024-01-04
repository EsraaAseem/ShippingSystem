using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.DataAccess.Helper.Configuration;
using ShippingSystem.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Client>Clients { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Employee> Employees { get; set; }
       public DbSet<BackUp> BackUps { get; set; }
        public DbSet<BackupStatus > BackupStatuses { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CompanyInformation> CompanyInformations { get; set; }
        public DbSet<ShipmentStatus> shipmentStatuses { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Invoice> Invoice { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ClientConfiguration).Assembly);
        }
    }
}
