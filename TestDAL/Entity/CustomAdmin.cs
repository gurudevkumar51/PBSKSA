using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDal.Entity
{
    public class CustomAdmin
    {
        public int AdminID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MailID { get; set; }
        public string Password { get; set; }
        public string AdminType { get; set; }
        public byte[] ThumbnailProfileImg { get; set; }
    }
}
