using PBSDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBSDAL.Mapper
{
   public class ContactMapper
    {
       public List<ContactForm> Map(IDataReader reader)
       {
           List<ContactForm> cntcts = new List<ContactForm>();
           while (reader.Read())
           {
               ContactForm cntct = new ContactForm();
               cntct.ID = Convert.ToInt32(reader["ID"].ToString());
               cntct.FullName = reader["FullName"].ToString();
               cntct.PhoneNo = reader["PhoneNo"].ToString();
               cntct.EmailID = reader["Email"].ToString();
               cntct.Subject = reader["Subject"].ToString();
               cntct.Message = reader["Message"].ToString();
               cntcts.Add(cntct);
           }
           return cntcts;
       }
    }
}
