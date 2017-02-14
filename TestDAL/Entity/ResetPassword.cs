using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AdminDal.Entity
{
    public class ResetPassword
    {
        public int AdminID { get; set; }
        
        [Required(ErrorMessage = "Please enter old password.")]
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        public string Old_Password { get; set; }

        [StringLength(20,MinimumLength=3,ErrorMessage="Password should be between 3 to 20 characters.")]
        [Required(ErrorMessage = "Please enter new password.")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string New_Password { get; set; }


        //[Required(ErrorMessage = "Please enter confirm password.")]
        [Display(Name = "Confirm Password")]
        [Compare("New_Password")]
        [DataType(DataType.Password)]
        public string Confirm_Password { get; set; }
    }
}
