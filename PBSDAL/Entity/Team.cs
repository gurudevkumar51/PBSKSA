using System;
using System.Collections.Generic;
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
        public string Skills { get; set; }
        public string Ar_Skills { get; set; }
        public string Expertise { get; set; }
        public string Ar_Expertise { get; set; }
    }
}
