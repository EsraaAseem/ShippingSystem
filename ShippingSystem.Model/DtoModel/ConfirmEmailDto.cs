using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class ConfirmEmailDto
    {
        [Required(ErrorMessage = "otp Reuired")]
        public string RecOtp { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
    }
}
