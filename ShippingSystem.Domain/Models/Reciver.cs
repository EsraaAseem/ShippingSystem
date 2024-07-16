using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Domain.Models
{
    public class Reciver
    {
        public Reciver(string name, string city, string streetAddress, string email, string phone)
        {
            Name = name;
            City = city;
            StreetAddress = streetAddress;
            Email = email;
            Phone = phone;
        }

        public string Name { get;private set; }
        public string City { get; private set; }
        public string StreetAddress { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
    }
}
