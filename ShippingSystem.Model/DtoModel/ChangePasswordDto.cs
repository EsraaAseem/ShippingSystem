using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "ref Token Reuired")]
        public string RefToken { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [StringLength(20, ErrorMessage = "Password Length", MinimumLength = 6)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [StringLength(20, ErrorMessage = "PasswordLength", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
