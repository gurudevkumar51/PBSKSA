using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AdminDal.Entity
{
    public class SchemeModel
    {
        public int SchemeID { get; set; }
        public string SchemeName { get; set; }
            
        [Display(Name = "User")]
        public string UserType { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> AdminID { get; set; }
        
        [UIHint("Is_Active")]
        [Display(Name = "Status")]
        public Nullable<bool> IsActive { get; set; }

           [Display(Name = "Bulletin")]
        public byte[] Scheme { get; set; }
        
        public byte[] SchemeThumbnail { get; set; }

        [Required(ErrorMessage = " Please select an image")]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose File")]
        public HttpPostedFileBase File { get; set; }

        public Admin Admin { get; set; }
    }
}
