using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdminDal.Entity
{
    public class EmailTemplate
    {
        [Display(Name = "Template ID")]
        public int Template_Id { get; set; }

        [Display(Name = "Mail Purpose")]
        [Required(ErrorMessage = "Please Enter Mail Purpose")]
        public string Mail_Purpose { get; set; }

        [Required(ErrorMessage="Please Enter Subject")]
        [Display(Name = "Mail Subject")]
        public string Mail_Subject { get; set; }
    
        [Display(Name = "Mail Content")]
        public string Mail_Content { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid Email Id")]     
        [Display(Name = "Mail From")]
        public string Mail_From { get; set; }

        [RegularExpression(@"^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*(;|,)\s*|\s*$))*$",ErrorMessage = "Please enter valid mail address.")]        
        [Display(Name = "Mail To")]
        public string Mail_To { get; set; }

        [RegularExpression(@"^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*(;|,)\s*|\s*$))*$", ErrorMessage = "Please enter valid mail address.")]
        [Display(Name = "Bcc")]
        public string Mail_bcc{ get; set; }

        [RegularExpression(@"^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*(;|,)\s*|\s*$))*$", ErrorMessage = "Please enter valid mail address.")]
        [Display(Name = "Cc")]
        public string Mail_Cc { get; set; }

        [Display(Name = "Mail Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> Mail_date { get; set; }

        [Display(Name = "Delete Status")]
        public Nullable<bool> Delete_Status { get; set; }


    }
}
