

namespace ShippingSystem.Domain.Models
{
    public class Employee:AppUser
    {
        private Employee(string firstName, string lastName,
            string? branchName, string? phoneNumber, string? email, string userName, string city, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            BranchName = branchName;
            PhoneNumber = phoneNumber;
            Email = email;
            UserName = userName;
            City = city;
            Address = address;

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string BranchName { get; private set; }
        public static Employee CreateEmployee(string firstName, string lastName,
            string? branchName, string? phoneNumber, string? email, string userName, string city, string address)
        {
            var employee=new Employee(firstName, lastName, branchName, phoneNumber, email, userName, city, address);
            return employee;
        }

    }
}
