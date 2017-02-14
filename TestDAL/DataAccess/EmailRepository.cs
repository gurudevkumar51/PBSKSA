using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AdminDal.Entity;
using AdminDal.Common;
using AdminDal.Mapper;
using System.Data.SqlClient;
using System.Web;
using Bodhtree.Common;
namespace AdminDal.DataAccess
{
    internal class EmailRepository : BaseRepository
    {
        Logging log = new Logging();

        public List<SmtpMail> GetSmtpDetails()
        {
            SmtpMapper objsmtpMapper = new SmtpMapper();
            SqlParameter[] parameters = 
            {                                           
                 new SqlParameter("@Type", "F")
            };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_SmtpDetails", parameters);
            using (reader)
            {
                return objsmtpMapper.Map(reader);
            }
        }
        public int AddSmtpDetails(SmtpMail objsmtp)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = 
            {      
            new SqlParameter("@Smtp_mailfrom", objsmtp.Smtp_mailfrom),
            new SqlParameter("@Smtp_Host", objsmtp.Smtp_Host),
            new SqlParameter("@Smtp_Port",objsmtp.Smtp_Port),
            new SqlParameter("@Smtp_username", objsmtp.Smtp_username),            
            new SqlParameter("@Smtp_password",objsmtp.Smtp_password),
            new SqlParameter("@Type","I")   
           };
                flag = base.ExecuteNonQuery("Insert_Update_Fetch_SmtpDetails", parameters);
                return flag;
            }
            catch (Exception e)
            {
                log.Logflatfile_Ex(e);
                return flag;
            }
        }
        public int EditSmtpDetails(SmtpMail smtp)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = 
            { 
            new SqlParameter("@Smtp_Id", smtp.Smtp_Id),
            new SqlParameter("@Smtp_mailfrom", smtp.Smtp_mailfrom),
            new SqlParameter("@Smtp_Host", smtp.Smtp_Host),
            new SqlParameter("@Smtp_Port",smtp.Smtp_Port),
            new SqlParameter("@Smtp_username", smtp.Smtp_username),
            new SqlParameter("@Smtp_password", smtp.Smtp_password),
            new SqlParameter("@Type","U"),
            };
                flag = base.ExecuteNonQuery("Insert_Update_Fetch_SmtpDetails", parameters);
            }
            catch (Exception e)
            {
                log.Logflatfile_Ex(e);
                return flag;
            }
            return flag;
        }

        public SmtpMail GetSmtpDetailsById(int? id)
        {
            SmtpMapper objMapper = new SmtpMapper();
            SqlParameter[] parameters = 
            {                 
                new SqlParameter("@Smtp_Id", id),          
                 new SqlParameter("@Type", "S")
            };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_SmtpDetails", parameters);
            using (reader)
            {
                return objMapper.SingleMap(reader);
            }
        }

        public List<EmailTemplate> GetMailDetails()
        {
            EmailMapper objemailMapper = new EmailMapper();
            SqlParameter[] parameters = 
            {                                           
                 new SqlParameter("@Type", "F")
            };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_MailDetails", parameters);
            using (reader)
            {
                return objemailMapper.Map(reader);
            }
        }

        public int AddEmailDetails(EmailTemplate objemail)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = 
            {      
            new SqlParameter("@MailPurpose", objemail.Mail_Purpose),
            new SqlParameter("@MailSubject", objemail.Mail_Subject),
            new SqlParameter("@MailContent", objemail.Mail_Content),
            new SqlParameter("@MailFrom", objemail.Mail_From),
            new SqlParameter("@MailBcc",objemail.Mail_bcc),
            new SqlParameter("@MailCc", objemail.Mail_Cc),
            new SqlParameter("@MailTo", objemail.Mail_To),
            new SqlParameter("@Type","I")            
           };
                flag = base.ExecuteNonQuery("Insert_Update_Fetch_MailDetails", parameters);
                return flag;
            }
            catch (Exception e)
            {
                log.Logflatfile_Ex(e);
                return flag;
            }
        }

        public int UpdateEmail(EmailTemplate objemail)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = 
            { 
            new SqlParameter("@TemplateId", objemail.Template_Id),
            new SqlParameter("@MailPurpose", objemail.Mail_Purpose),
            new SqlParameter("@MailSubject", objemail.Mail_Subject),
            new SqlParameter("@MailContent", objemail.Mail_Content),
            new SqlParameter("@MailFrom", objemail.Mail_From),
            new SqlParameter("@MailBcc",objemail.Mail_bcc),
            new SqlParameter("@MailCc", objemail.Mail_Cc),
            new SqlParameter("@MailTo", objemail.Mail_To),
            new SqlParameter("@Type","U"),
            };
                flag = base.ExecuteNonQuery("Insert_Update_Fetch_MailDetails", parameters);
            }
            catch (Exception e)
            {
                log.Logflatfile_Ex(e);
                return flag;
            }
            return flag;
        }

        public EmailTemplate GetEmailById(int? id)
        {
            EmailMapper objemailMapper = new EmailMapper();
            SqlParameter[] parameters = 
            {                 
                new SqlParameter("@TemplateId", id),          
                 new SqlParameter("@Type", "S")
            };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_MailDetails", parameters);
            using (reader)
            {
                return objemailMapper.SingleMap(reader);
            }
        }
        public int DeleteMail(int id)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = 
            {      
            new SqlParameter("@TemplateId", id),
            new SqlParameter("@Type","D")
           };
                flag = base.ExecuteNonQuery("Insert_Update_Fetch_MailDetails", parameters);
                return flag;
            }
            catch (Exception e)
            {
                log.Logflatfile_Ex(e);
                return flag;
            }
        }
    }
}
