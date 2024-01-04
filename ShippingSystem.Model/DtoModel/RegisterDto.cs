using Microsoft.AspNetCore.Http;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.HelperModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class RegisterDto:Register
    {
        public string CompanyName {get; set;}
      //  public DateTime JobStart { get; set;}
      //  public float Salary {get; set;}
        public string? Role {get; set;}
        public string RoleName {get; set;}
        public int RoleId { get; set; }
        public IFormFile? Image { get; set; }
        public string? Logo { get; set; }
    }
}
