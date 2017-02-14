using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AdminDal.Entity
{
    public class SmtpMail
    {
        public int Smtp_Id{ get; set; }
        [Display(Name="Mail From")]
        [Required(ErrorMessage = "Please enter senders mail address.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid Email Id")]
        public string Smtp_mailfrom { get; set; }

        [Display(Name = "SMTP Host")]
        [RegularExpression(@"^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|it|uk|edu|COM|ORG|NET|MIL|EDU)$", ErrorMessage = "Please enter valid Host Name.")]        
        [Required(ErrorMessage = "Please enter host name.")]     
        public string Smtp_Host { get; set; }

        [Display(Name = "User Email Id")]
        [Required(ErrorMessage = "Please enter Email Id.")]
        [MaxLength(70,ErrorMessage="Email Id Should not be more than 70 charachters.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid Email Id")]
        public string Smtp_username { get; set; }

        [Display(Name = "Password")]
        [MaxLength(50, ErrorMessage = "Password Should not be more than 50 charachters.")]
        [Required(ErrorMessage = "Please enter password.")]
        public string Smtp_password { get; set; }

        [Display(Name = "SMTP Port")]
        [Required(ErrorMessage = "Please enter Port.")]
        public int Smtp_Port { get; set; }
    }
}
