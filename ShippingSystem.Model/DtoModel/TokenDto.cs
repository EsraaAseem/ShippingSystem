using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class TokenDto
    {
        [Required(ErrorMessage = "ref Token Reuired")]
        public string RefToken { get; set; }
    }

}
