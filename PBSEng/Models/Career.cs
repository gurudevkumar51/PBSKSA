using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBSEng.Models
{
    public class Career
    {
        public int ID { get; set; }
        public string Designation { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string EmailID { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}