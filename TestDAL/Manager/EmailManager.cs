using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDal.Entity;
using AdminDal.DataAccess;

namespace AdminDal.Manager
{
    public class EmailManager
    {
        EmailRepository _objEmailReps = new EmailRepository();

        public List<SmtpMail> GetSmtpDetails()
        {
            return _objEmailReps.GetSmtpDetails();
        }
        public int AddSmtpDetails(SmtpMail smtp)
        {
            return _objEmailReps.AddSmtpDetails(smtp);
        }
        public int EditSmtpDetails(SmtpMail smtp)
        {
            return _objEmailReps.EditSmtpDetails(smtp);
        }
        public SmtpMail GetSmtpDetailsById(int? id)
        {
            return _objEmailReps.GetSmtpDetailsById(id);
        }
        public List<EmailTemplate> GetMailDetails()
        {
            return _objEmailReps.GetMailDetails();
        }
        public int AddEmails(EmailTemplate email)
        {
            return _objEmailReps.AddEmailDetails(email);
        }
        public EmailTemplate GetEmailById(int? id)
        {
            return _objEmailReps.GetEmailById(id);
        }
        public int UpdateEmail(EmailTemplate email)
        {
            return _objEmailReps.UpdateEmail(email);
        }
        public int DeleteMail(int id)
        {
            return _objEmailReps.DeleteMail(id);
        }
    }
}
