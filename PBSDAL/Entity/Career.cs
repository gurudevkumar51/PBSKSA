using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PBSDAL.Entity
{
    public class Career
    {
        public int ID { get; set; }
        public string Designation { get; set; }
        public string FullName { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
        
        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }
        public string ResumePath { get; set; }
    }
}
