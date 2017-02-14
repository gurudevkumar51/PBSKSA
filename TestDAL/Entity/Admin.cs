using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AdminDal.Entity
{
    public class Admin
    {
        public int AdminID { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[System.Web.Mvc.Remote("IsAdminExists", "Admin")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid Email Id")]
        [Required(ErrorMessage = "Please enter your Email Address.")]
        [Display(Name = "Email ID")]
        public string MailID { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password should be between 3 to 20 characters.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string Confirm_Password { get; set; }

        [UIHint("Is_Active")]
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

        public string AdminType { get; set; }

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
