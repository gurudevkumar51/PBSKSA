using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDal.Entity;
using System.Data;

namespace AdminDal.Mapper
{
    public class EmailMapper : IMapper<List<EmailTemplate>>
    {
        public List<EmailTemplate> Map(IDataReader reader)
        {
            List<EmailTemplate> emails = new List<EmailTemplate>();
            while (reader.Read())
            {
                EmailTemplate email = new EmailTemplate();
                email.Template_Id = Convert.ToInt32(reader["TemplateId"].ToString());
                email.Mail_Purpose = reader["MailPurpose"].ToString();
                email.Mail_Subject = reader["MailSubject"].ToString();
                email.Mail_Content = reader["MailContent"].ToString();
                email.Mail_From = reader["MailFrom"].ToString();
                email.Mail_bcc = reader["MailBcc"].ToString();
                email.Mail_Cc = reader["MailCc"].ToString();
                email.Mail_To = reader["MailTo"].ToString();
                email.Mail_date = Convert.ToDateTime(reader["DateCreated"].ToString());
                email.Delete_Status = Convert.ToBoolean(reader["DeleteStatus"].ToString());
                emails.Add(email);
            }
            return emails;
        }
        public EmailTemplate SingleMap(IDataReader reader)
        {
            EmailTemplate email = new EmailTemplate();
            while (reader.Read())
            {                
                email.Template_Id = Convert.ToInt32(reader["TemplateId"].ToString());
                email.Mail_Purpose = reader["MailPurpose"].ToString();
                email.Mail_Subject = reader["MailSubject"].ToString();
                email.Mail_Content = reader["MailContent"].ToString();
                email.Mail_From = reader["MailFrom"].ToString();
                email.Mail_bcc = reader["MailBcc"].ToString();
                email.Mail_Cc = reader["MailCc"].ToString();
                email.Mail_To = reader["MailTo"].ToString();
                email.Mail_date = Convert.ToDateTime(reader["DateCreated"].ToString());
                email.Delete_Status = Convert.ToBoolean(reader["DeleteStatus"].ToString());                
            }
            return email;
        }
    }
}
