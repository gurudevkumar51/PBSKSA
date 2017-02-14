using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDal.Entity;
using System.Data;

namespace AdminDal.Mapper
{
   public class SmtpMapper
    {
        public List<SmtpMail> Map(IDataReader reader)
        {
            List<SmtpMail> smails = new List<SmtpMail>();
            while (reader.Read())
            {
                SmtpMail smail = new SmtpMail();
                smail.Smtp_Id = Convert.ToInt32(reader["Smtp_Id"].ToString());
                smail.Smtp_mailfrom = reader["Smtp_mailfrom"].ToString();
                smail.Smtp_Host = reader["Smtp_Host"].ToString();
                smail.Smtp_Port = Convert.ToInt32(reader["Smtp_Port"]);
                smail.Smtp_username = reader["Smtp_username"].ToString();
                smail.Smtp_password= reader["Smtp_password"].ToString();
                smails.Add(smail);
            }
            return smails;
        }
        public SmtpMail SingleMap(IDataReader reader)
        {
            SmtpMail smtp = new SmtpMail();
            while (reader.Read())
            {
                smtp.Smtp_Id = Convert.ToInt32(reader["Smtp_Id"].ToString());
                smtp.Smtp_mailfrom = reader["Smtp_mailfrom"].ToString();
                smtp.Smtp_Host = reader["Smtp_Host"].ToString();
                smtp.Smtp_Port = Convert.ToInt32(reader["Smtp_Port"]);
                smtp.Smtp_username = reader["Smtp_username"].ToString();
                smtp.Smtp_password = reader["Smtp_password"].ToString();
            }
            return smtp;
        }
    }
}
