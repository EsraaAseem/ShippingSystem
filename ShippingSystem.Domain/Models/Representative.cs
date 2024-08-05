using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Domain.Models
{
    public class Representative:AppUser
    {
        private Representative(string firstName, string lastName, string? governorate, 
            string? branchName,string? phoneNumber,string? email,string userName,string city,string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Governorate = governorate;
            BranchName = branchName;
            PhoneNumber=phoneNumber;
            Email=email;
            UserName=userName;
            City = city;
            Address = address;

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public  string? Governorate { get; private set; }
        public string? BranchName { get; private set; }

        public static Representative CreateRepresentative(string firstName, string lastName, string? governorate,
            string? branchName, string? phoneNumber, string? email, string userName,string city,
            string address)
        {
            var represent=new Representative(firstName, lastName, governorate, branchName, phoneNumber, email, userName,city,address);
            return represent;
        }
        public void UpdateRepresentative(string firstName, string lastName, string? governorate,
            string? branchName, string? phoneNumber, string? email, string userName, string city,
            string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Governorate = governorate;
            BranchName = branchName;
            PhoneNumber = phoneNumber;
            Email = email;
            UserName = userName;
            City = city;
            Address = address;

        }
    }
}
