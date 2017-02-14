using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AdminDal.Entity
{
    public class Account
    {
        public int AccountId { get; set; }
        
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Username should be between 3 to 20 characters.")]
        [Required(ErrorMessage = "Please enter username.")]
        [Display(Name = "User Name")]
        public string AccountName { get; set; }

        public string RCode { get; set; }

        [Required(ErrorMessage = "Please enter phone number.")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please select user type.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password should be between 3 to 20 characters.")]
        public string Password { get; set; }

        public bool IsReset { get; set; }

        [UIHint("Is_Active")]
        [Display(Name = "Status")]
        public bool Status { get; set; }

        public bool IsDeleted { get; set; }

        //[System.Web.Mvc.Remote("IsUserExists", "Admin")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid Email Id")]
        [Required(ErrorMessage = "Please enter your Email Id.")]
        [Display(Name = "Email ID")]
        public string EmailId { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string Confirm_Password { get; set; }

        public byte[] ProfileImg { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Profile Picture")]
        public HttpPostedFileBase File { get; set; }
        
		[Display(Name = "Profile Picture")]
        public string ProfileImgName { get; set; }

        public bool DefaultImage { get; set; }

        public byte[] ThumbnailProfileImg { get; set; }        
    }
}
