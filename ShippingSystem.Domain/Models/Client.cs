
using static System.Net.Mime.MediaTypeNames;

namespace ShippingSystem.Domain.Models
{
    public class Client:AppUser
    {
        public string CompanyName { get; private set; }
        public string Logo { get; private set; }
        public string? Governorate { get; private set; }
        public string? Branch { get; private set; }

       // public IReadOnlyCollection<City>? Cities { get; private set; }
       public void UpdateClient( string email, string userName, string? phoneNumber,string address, string companyName,string logo,
        string Covernorate,
        string city,
        string branch)
        {
            Email = email;
           UserName =userName;
           NormalizedUserName =userName.ToUpper();
           NormalizedEmail =email.ToUpper();
           PhoneNumber =phoneNumber;
           Address = address;
           CompanyName = companyName;
           Logo = logo;
           Governorate = Covernorate;
           City = city;
           Branch = branch;
        }

    }
}
