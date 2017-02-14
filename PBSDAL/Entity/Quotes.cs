using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBSDAL.Entity
{
    public class Quotes
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter quotation")]
        [DisplayName("Quote")]
        public string Quote { get; set; }

        [Required(ErrorMessage = "Enter the Author Name")]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "مؤلف")]
        [DisplayName("اقتبس")]
        public string AR_Quote { get; set; }
        
        [Required(ErrorMessage = "مؤلف")]
        [DisplayName("مؤلف")]
        public string AR_Author { get; set; }

        public DateTime Added_Date { get; set; }
        public Boolean Is_Active { get; set; }        
    }
}
