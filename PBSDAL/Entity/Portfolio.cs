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
    public class Portfolio
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage="Enter your Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter your Title")]
        public string AR_Title { get; set; }

        [Required(ErrorMessage = "Enter your Location name")]
        public string Location_Name { get; set; }

        [Required(ErrorMessage = "Enter your Title")]
        public string AR_Location_Name { get; set; }

        [Required(ErrorMessage = "Select date from date picker")]
        [DisplayName("Organize Date")]
        public DateTime _Date { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload Portfolio image")]
        public HttpPostedFileBase File { get; set; }

        public byte[] ByteImage { get; set; }

        public byte[] ByteImageThumbnail { get; set; }
        
        public string thumbnailPath { get; set; }

        public string Image_Path { get; set; }        
        
        [DisplayName("Added Date")]
        public DateTime Added_Date { get; set; }
        
        public Boolean Is_Active { get; set; }
    }
}