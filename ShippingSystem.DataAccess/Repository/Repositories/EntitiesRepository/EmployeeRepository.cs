using Microsoft.EntityFrameworkCore;
using ShippingSystem.DataAccess.Data;
using ShippingSystem.DataAccess.Repository.IRepositories.IEntitiesRepository;
using ShippingSystem.DataAccess.Repository.Repositories.BaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.Exceptions.RequestExceptions;

namespace ShippingSystem.DataAccess.Repository.Repositories.EntitiesRepository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Employee> UpdateEmployeeAsync(string Id, EmployeeUpdateDto employeeupdate)
        {

            var employee = await _db.Employees.FirstOrDefaultAsync(c => c.Id == Id);
            if (employee == null)
                throw new NotFoundException("Employee not found");
                employee.Name = employeeupdate.Name;
                employee.City = employeeupdate.City;
                employee.Email = employeeupdate.Email;
                employee.PhoneNumber = employeeupdate.PhoneNumber;
                employee.UserName = employeeupdate.UserName;
                employee.PostalCode = employeeupdate.PostalCode;
             //   employee.Salary = employeeupdate.Salary;
              //  employee.RoleId = employeeupdate.RoleId;
                _db.Employees.Update(employee);
                await _db.SaveChangesAsync();
                return employee;
        }
    }
}
