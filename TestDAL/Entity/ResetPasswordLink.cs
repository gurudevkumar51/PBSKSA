using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AdminDal.Entity
{
    public class ResetPasswordLink
    {
        public string id { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password should be between 3 to 20 characters.")]
        [Required(ErrorMessage = "Please enter new password.")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please enter confirm password.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
