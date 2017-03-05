using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PBSDAL.Entity
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ar_Name  { get; set; }
        public string Designation { get; set; }
        public string Ar_Designation { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }
        public string ImagePath { get; set; }

        [DisplayName("What I do! (My job)")]
        public string MyJob { get; set; }

        [DisplayName(".. ماذا اعمل ؟")]
        public string ArMyJob { get; set; }
        
        [DisplayName("One Secret About me")]
        public string Secret { get; set; }

        [DisplayName(".. احد اسراري")]
        public string ArSecret { get; set; }
        
        [DisplayName("Facts about me")]
        public string facts { get; set; }

        [DisplayName(".. احد الحقائق عني")]
        public string Arfacts { get; set; }
        
        [DisplayName("In another life I would be")]
        public string AnotherLife { get; set; }

        [DisplayName(".. في الحياة الاخرى سأكون")]
        public string ArAnotherLife { get; set; }
        
        [DisplayName("Quote")]
        public string Quote { get; set; }

        [DisplayName(".. إقتباس")]
        public string ArQuote { get; set; }
    }
}
