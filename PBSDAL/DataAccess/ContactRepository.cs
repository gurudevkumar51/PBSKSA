using PBSDAL.Entity;
using PBSDAL.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBSDAL.DataAccess
{
    class ContactRepository : BaseRepository
    {        
        public int AddContact(ContactForm cntct)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = {                              
                        new SqlParameter("@FullName", cntct.FullName),
                        new SqlParameter("@PhoneNumber", cntct.PhoneNo),                        
                        new SqlParameter("@EmailID", cntct.EmailID),
                        new SqlParameter("@Subject",  cntct.Subject),
                        new SqlParameter("@Message",  cntct.Message),
                        new SqlParameter("@Type","B"),
                        };
                flag = ExecuteNonQuery("Manage_ContactForm", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public List<ContactForm> GetContacts()
        {
            ContactMapper objCntctMapper = new ContactMapper();
            SqlParameter[] parameters = {                                           
                 new SqlParameter("@Type", "A")
            };
            IDataReader reader = base.GetReader("Manage_ContactForm", parameters);
            using (reader)
            {
                return objCntctMapper.Map(reader);
            }
        }
    }
}

