using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Configuration;


namespace ShippingSystem.Presistance.Data
{
    public class ShippingSystemContext : IdentityDbContext<AppUser>
    {
        public ShippingSystemContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ClientAddRequest> ClientRequest { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Beackup> Beackups { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShipmentStatus> ShipmentStatuses { get; set; }
        public DbSet<ShipmentType> ShipmentTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
             builder.ApplyConfigurationsFromAssembly(typeof(AccountConfig).Assembly);


            #region
            builder.Entity<AppUser>().ToTable("Accounts", "Account");
            builder.Entity<IdentityRole>().ToTable("Roles", "Account");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Account");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Account");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Account");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Account");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Account");
            builder.Entity<AppUser>().HasIndex(x => x.Email).IsUnique(false);
            #endregion
        }
    }
}
