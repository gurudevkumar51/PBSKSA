using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace PBSDAL.Entity
{
    public class Testimonial
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Testimonial Author")]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Enter Testimonial Author in Arabic")]
        [DisplayName("Arabic Author")]
        public string Ar_Author { get; set; }
                
        public DateTime Added_Date { get; set; }
                
        public Boolean Is_Active { get; set; }

        [Required(ErrorMessage = "Enter Testimonial Author Date")]
        public DateTime Author_Date { get; set; }
        
        public string Image_Path { get; set; }

        //[Required(ErrorMessage = "Enter Testimonial Author Image")]
        [DataType(DataType.Upload)]
        [Display(Name = "Testimonial Author Image")]
        public HttpPostedFileBase File { get; set; }

        public byte[] ByteImage { get; set; }

        public byte[] ByteImageThumbnail { get; set; }

        public string thumbnailPath { get; set; }        

        [Required(ErrorMessage = "Enter Testimonial Source")]
        public string Resource_Link { get; set; }

        [Required(ErrorMessage = "Enter Testimonial Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter Testimonial Description in Arabic")]
        public string Ar_Description { get; set; }
    }
}
