using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBSDAL.Entity
{
    public class ContactForm
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string EmailID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
