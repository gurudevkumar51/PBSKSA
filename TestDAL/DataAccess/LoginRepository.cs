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
using System.IO;
using Bodhtree.Common;
using System.Web.Security;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace AdminDal.DataAccess
{
   internal class LoginRepository : BaseRepository
    {
        Logging log = new Logging();
        EmailRepository MailRepoobj = new EmailRepository();
        public int ForgetPass(string mail)
        {
            int flag = 0;
            try
            {
                AdminMapper objAccountDetailMapper = new AdminMapper();
                SqlParameter[] parameters = {
                                           new SqlParameter("@MailID", mail),                                           
                                           new SqlParameter("@Type","P")
                                       };
                IDataReader reader = base.GetReader("Insert_Update_Fetch_Admin", parameters);
                using (reader)
                {
                    List<Admin> objAccount = new List<Admin>();
                    objAccount = objAccountDetailMapper.Map(reader);
                    string id, userMail;
                    if (objAccount.Count > 0)
                    {
                        id = Convert.ToString(objAccount[0].AdminID);
                        userMail = Convert.ToString(objAccount[0].MailID);
                        if (!String.IsNullOrEmpty(id))
                        {
                            flag++;
                            string eId = Cryptography.TDESEncryption(id, Types.GetEnumDescription(Types.Key.Password) + "/" + DateTime.Now.ToString("M/d/yyyy"));
                            EmailTemplate emailTempObj = new EmailTemplate();
                            SmtpMail smtpobj = new SmtpMail();
                            emailTempObj = MailRepoobj.GetEmailById(Convert.ToInt32(Types.MailTemplateCofig.ForgetPassword));
                            smtpobj = MailRepoobj.GetSmtpDetailsById(1);
                            emailTempObj.Mail_Content = emailTempObj.Mail_Content.Replace("{Name}", userMail);
                            emailTempObj.Mail_Content = emailTempObj.Mail_Content.Replace("{Key}", eId);
                            emailTempObj.Mail_To = mail;
                            //bool val = GenericClass.sendMail(emailTempObj, smtpobj);
                            //if (val)
                            //{
                            //    flag = 2;
                            //}
                        }
                        else
                        {
                            flag = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Logflatfile_Ex(ex);
                return flag;
            }
            return flag;
        }        

        public void SetFormAuthCookie(Admin accountObj, bool remember)
        {
            CustomAdmin serializeModel = new CustomAdmin();
            serializeModel.AdminID = accountObj.AdminID;
            serializeModel.MailID = accountObj.MailID;
            serializeModel.Password = accountObj.Password;
            serializeModel.FirstName = accountObj.FirstName;
            serializeModel.LastName = accountObj.LastName;
            serializeModel.AdminType = accountObj.AdminType;
            //serializeModel.ThumbnailProfileImg = accountObj.ThumbnailProfileImg;

            string userData = JsonConvert.SerializeObject(serializeModel);
            //create the authentication ticket
            var authTicket = new FormsAuthenticationTicket(
              1,
              serializeModel.AdminID.ToString(),
              DateTime.Now,
              DateTime.Now.AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["DefaultCookieMin"].ToString())),
              remember,
             userData
            );

            //encrypt the ticket and add it to a cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
            HttpContext.Current.Response.Cookies.Add(cookie);

            if (remember)
            {
                //encode
                string encodedValue = GenericClass.Encode(Convert.ToString(accountObj.AdminID), "Remember");

                HttpCookie cookieRem = new HttpCookie("_RememberAdminCookie");
                cookieRem.Values["Id"] = encodedValue;
                cookieRem.Expires = DateTime.Now.AddDays(Convert.ToInt32(ConfigurationManager.AppSettings["RememberCookieDay"].ToString()));

                HttpContext.Current.Response.Cookies.Add(cookieRem);
            }
            else
            {
                //clear cookie
                HttpCookie cookieRem = new HttpCookie("_RememberAdminCookie", null);
                cookieRem.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookieRem);
            }
        }

        public string GetRememberCookie()
        {
            string flag = null;
            HttpCookie cookie = HttpContext.Current.Request.Cookies["_RememberAdminCookie"];
            if (cookie != null)
            {
                string id = HttpContext.Current.Request.Cookies["_RememberAdminCookie"]["Id"].ToString();
                flag = GenericClass.Decode(id, "Remember");
            }
            return flag;
        }

        public List<Admin> GetAdmin(Login acc)
        {
            AdminMapper objAdminDetailMapper = new AdminMapper();
            acc.Password = Cryptography.TDESEncryption(acc.Password, Types.GetEnumDescription(Types.Key.Password));
            SqlParameter[] parameters = {
                                           new SqlParameter("@MailID", acc.UserName),
                                           new SqlParameter("@Password", acc.Password),
                                           new SqlParameter("@Type","F")
                                       };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_Admin", parameters);
            using (reader)
            {
                return objAdminDetailMapper.Map(reader);
            }
        }
 
    }
}
