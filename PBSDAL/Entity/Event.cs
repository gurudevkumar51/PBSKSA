using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PBSDAL.Entity
{
    public class Event
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage="Enter your Title in English")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ادخل عنوان الحدث")]
        [DisplayName("عنوان")]
        public string Arabic_Title { get; set; }

        [Required(ErrorMessage = "Enter your Event Date")]
        [DisplayName("تاريخ الحدث (Event Date)")]
        public DateTime _Date { get; set; }        
        
        [Required(ErrorMessage = "Enter your Event Description in English")]
        [DisplayName("Event Description")]
        [AllowHtml]
        public string Description { get; set; }

        [Required(ErrorMessage = "ادخل وصف الحدث")]
        [DisplayName("وصف الحدث")]
        [AllowHtml]
        public string Arabic_Description { get; set; }

        [Required(ErrorMessage = "Enter the location of event in English")]
        [DisplayName("Event Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = " ادخل موقع الحدث")]
        [DisplayName("موقع الحدث")]
        public string Arabic_Location { get; set; }

        [Required(ErrorMessage = "Enter GoogleMap URL Location = ادخل رابط لموقع الحدث على خرائط قوقل")]
        [DisplayName("Map URL")]
        [Url(ErrorMessage = "URL format is wrong!")]
        public string Location_URL { get; set; }

        [DisplayName("موعد الدخول(Added Date)")]
        public DateTime Added_Date { get; set; }

        [DisplayName("الحالة(Status)")]
        public Boolean IS_Active { get; set; }
    }
}
