using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Models;
using ShippingSystem.Domain.Share;
using ShippingSystem.Presistance.Data;
using ShippingSystem.Shared;
using System.Data;
using System.Security.Claims;

namespace ShippingSystemApi.migratserv
{
    public  class Inlize : IInlize
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ShippingSystemContext _db;

        public Inlize(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ShippingSystemContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }
    
        public async void intials()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

           
            if (!_roleManager.RoleExistsAsync(Roles.Role_SuperAdmin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Roles.Role_Client)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.Role_Representative)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.Role_SuperAdmin)).GetAwaiter().GetResult();
                  var employee = Employee.CreateEmployee("Ali", "Gamal", "Sohag", "+2011876876", "SuperAdmin@gmail.com", "Ali123", "Sohag", "Sohag/tahta");
                   _userManager.CreateAsync(employee, "SuperAdmin&123").GetAwaiter().GetResult();
                   Employee user = _db.Employees.FirstOrDefault(u => u.Email == "SuperAdmin@gmail.com");
                   _userManager.AddToRoleAsync(user, Roles.Role_SuperAdmin).GetAwaiter().GetResult();
                  var adminRole =await _roleManager.FindByNameAsync(Roles.Role_SuperAdmin);
                var allClaims = await _roleManager.GetClaimsAsync(adminRole);
              var allPermissions = Permissions.GenerateAllPermissions();

              foreach (var permission in allPermissions)
              {
                  if (!allClaims.Any(c => c.Type == "Permission" && c.Value == permission))
                      await _roleManager.AddClaimAsync(adminRole, new Claim("Permission", permission));
              }              

            }
            return;
        }


    }
}
