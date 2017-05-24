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

        [DisplayName("Category")]
        public string TeamCategory { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }

        public string ImagePath { get; set; }

        [DisplayName("What I do! (My job)")]
        public string MyJob { get; set; }

        [DisplayName(".. ماذا اعمل ؟")]
        public string ArMyJob { get; set; }
    }
}
