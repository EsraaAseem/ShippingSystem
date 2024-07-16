using ShippingSystem.Domain.Helper;
using System;
using System.Collections.Generic;


namespace ShippingSystem.Domain.Models
{
    public class ClientAddRequest:Entity
    {
        private ClientAddRequest(Guid id,string email,string userName,string password,string name,string? phoneNumber,
            string streetAddress,string?companyName,string logo,string? governorate, string city,string branch): base(id)
        {
            Email = email;
            UserName = userName;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
            StreetAddress = streetAddress !;
            CompanyName = companyName;
            Logo = logo;
            Governorate = governorate;
            City = city;
            Branch = branch;
        }

        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; set; }
        public string Name { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? StreetAddress { get; private set; }
        public string? CompanyName { get; private set; }
        public string Logo { get; private set; }
        public string? Governorate { get; private set; }
        public string? City { get; private set; }
        public string? Branch { get; private set; }
        public static ClientAddRequest CreateClientAddRequest(Guid id, string email,string userName, string password, string name, string phone,
            string streetAdress, string? companyName, string logo, string? gover, string city, string branch)
        {
            var clientRequest=new ClientAddRequest(id, email,userName, password, name, phone, streetAdress, companyName, logo, gover, city, branch);
            return clientRequest;
        }
   
    }
}
