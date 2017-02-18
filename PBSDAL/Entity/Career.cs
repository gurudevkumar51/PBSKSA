using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PBSDAL.Entity
{
    public class Career
    {
        public int ID { get; set; }
        public string Designation { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string EmailID { get; set; }
        public HttpPostedFileBase File { get; set; }
        public string ResumePath { get; set; }
    }
}
