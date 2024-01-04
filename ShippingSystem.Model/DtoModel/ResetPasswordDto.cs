using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "user Name Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [StringLength(20, ErrorMessage = "PasswordLength", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
