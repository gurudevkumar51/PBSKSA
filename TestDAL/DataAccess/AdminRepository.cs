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
using System.Web.Security;
using System.IO;
using System.Configuration;
using System.Drawing;

namespace AdminDal.DataAccess
{
    internal class AdminRepository : BaseRepository
    {
        Logging log = new Logging();
        public int UpdateProfilePhoto(Admin act)
        {
            int flag = 0;
            if (act.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(act.File.FileName);
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    act.ProfileImgName = act.FirstName + "_" + D + m + y + "_" + DtTick + ext;

                    using (var binaryReader = new BinaryReader(act.File.InputStream))
                        act.ProfileImg = binaryReader.ReadBytes(act.File.ContentLength);
                    //thumbnail storing
                    byte[] myByte = act.ProfileImg;
                    Image i;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(myByte, 0, myByte.Length);
                        i = Image.FromStream(ms);
                    }
                    act.ThumbnailProfileImg = GenericClass.imageToByteArray(i.GetThumbnailImage(75, 75, () => false, IntPtr.Zero));
                    path = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProfileImagePath"].ToString()), act.ProfileImgName);
                    File.WriteAllBytes(path, act.ProfileImg);
                }
            }
            SqlParameter[] parameters = 
                {   
                    new SqlParameter("@AdminID", act.AdminID), 
                    new SqlParameter("@ProfileImg", act.ProfileImg),
                    new SqlParameter("@ProfileImgName", act.ProfileImgName),
                    new SqlParameter("@ThumbnailProfileImg", act.ThumbnailProfileImg),
                    new SqlParameter("@Type","C")
                };
            flag = ExecuteNonQuery("Insert_Update_Fetch_Admin", parameters);
            return flag;
        }

        public KeyValuePair<int, int> AddUser(Account act)
        {
            act.Password = Cryptography.TDESEncryption(act.Password, Types.GetEnumDescription(Types.Key.Password));
            int flag = 0;
            int flagMail = 0;
            if (act.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(act.File.FileName);
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                      act.ProfileImgName = act.AccountName + "_" + D + m + y + "_" + DtTick + ext;
                      using (var binaryReader = new BinaryReader(act.File.InputStream))
                      act.ProfileImg = binaryReader.ReadBytes(act.File.ContentLength);

                    //thumbnail storing
                    byte[] myByte = act.ProfileImg;
                    Image i;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(myByte, 0, myByte.Length);
                        i = Image.FromStream(ms);
                    }
                    act.ThumbnailProfileImg = GenericClass.imageToByteArray(i.GetThumbnailImage(100, 100, () => false, IntPtr.Zero));

                    //compress image
                    act.ProfileImg = GenericClass.CompressSize(act.ProfileImg);
                    //Saving to /ProfileImage Folder
                    path = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProfileImagePath"].ToString()), act.ProfileImgName);
                    File.WriteAllBytes(path, act.ProfileImg);

                }
            }
            else
            {
                act.ProfileImg = new byte[] { };
                act.ThumbnailProfileImg = new byte[] { };
            }
            SqlParameter[] parameters = 
            {      
                    new SqlParameter("@AccountName", act.AccountName),   
                    new SqlParameter("@Password",act.Password),      
                    new SqlParameter("@Phone", act.Phone),
                    new SqlParameter("@Email", act.EmailId),
                    new SqlParameter("@UserType", act.Type),
                    new SqlParameter("@ProfileImg", act.ProfileImg),
                    new SqlParameter("@ProfileImgName", act.ProfileImgName),
                    new SqlParameter("@ThumbnailProfileImg", act.ThumbnailProfileImg),
                    new SqlParameter("@Type","I")
            };
            flag = ExecuteNonQuery("Insert_Update_Fetch_Account", parameters);
            string id, userName;
            Account acc2 = new Account();
            acc2 = GetAllUserAccount().Where(x => x.EmailId == act.EmailId).SingleOrDefault();
            id = Convert.ToString(acc2.AccountId);
            userName = Convert.ToString(acc2.AccountName);
            if (!String.IsNullOrEmpty(id) && flag > 0)
            {
                string eId = Cryptography.TDESEncryption(id, Types.GetEnumDescription(Types.Key.Password) + "/" + DateTime.Now.ToString("M/d/yyyy"));
                EmailTemplate emailTempObj = new EmailTemplate();
                SmtpMail smtpobj = new SmtpMail();
                EmailRepository mailrepo = new EmailRepository();
                emailTempObj = mailrepo.GetEmailById(Convert.ToInt32(Types.MailTemplateCofig.WelcomeUser));
                smtpobj = mailrepo.GetSmtpDetailsById(1);
                emailTempObj.Mail_Content = emailTempObj.Mail_Content.Replace("{Name}", userName);
                emailTempObj.Mail_Content = emailTempObj.Mail_Content.Replace("{Key}", eId);
                emailTempObj.Mail_To = acc2.EmailId;
                //bool val = GenericClass.sendMail(emailTempObj, smtpobj);
                //if (val)
                //{
                //    flagMail = 1;
                //}
            }
            return new KeyValuePair<int, int>(flag, flagMail);
        }        

        public KeyValuePair<int, int> AddAdmin(Admin adm)
        {
            adm.Password = Cryptography.TDESEncryption(adm.Password, Types.GetEnumDescription(Types.Key.Password));
            int flag = 0;
            int flagMail = 0;
            if (adm.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(adm.File.FileName);
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    adm.ProfileImgName = adm.FirstName + D + m + y + "_" + DtTick + ext;
                    using (var binaryReader = new BinaryReader(adm.File.InputStream))
                        adm.ProfileImg = binaryReader.ReadBytes(adm.File.ContentLength);
                    //thumbnail storing
                    byte[] myByte = adm.ProfileImg;
                    Image i;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(myByte, 0, myByte.Length);
                        i = Image.FromStream(ms);
                    }
                    adm.ThumbnailProfileImg = GenericClass.imageToByteArray(i.GetThumbnailImage(100, 100, () => false, IntPtr.Zero));
                    //compress image
                    adm.ProfileImg = GenericClass.CompressSize(adm.ProfileImg);
                    path = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProfileImagePath"].ToString()), adm.ProfileImgName);
                    File.WriteAllBytes(path, adm.ProfileImg);
                }
            }
            else
            {
                adm.ProfileImg = new byte[] { };
                adm.ThumbnailProfileImg = new byte[] { };
            }
            SqlParameter[] parameters = 
                {                          
                    new SqlParameter("@FirstName", adm.FirstName),
                    new SqlParameter("@LastName", adm.LastName),     
                    new SqlParameter("@Password", adm.Password),  
                    new SqlParameter("@MailID", adm.MailID), 
                    new SqlParameter("@ProfileImg", adm.ProfileImg),
                    new SqlParameter("@ProfileImgName", adm.ProfileImgName),
                    new SqlParameter("@ThumbnailProfileImg", adm.ThumbnailProfileImg),
                    new SqlParameter("@Type","I")
                };
            flag = ExecuteNonQuery("Insert_Update_Fetch_Admin", parameters);
            string id, userName;
            Admin acc2 = new Admin();
            acc2 = GetAllAdmin().Where(x => x.MailID == adm.MailID).SingleOrDefault();
            id = Convert.ToString(acc2.AdminID);
            userName = Convert.ToString(acc2.FirstName);
            if (!String.IsNullOrEmpty(id) && flag > 0)
            {
                string eId = Cryptography.TDESEncryption(id, Types.GetEnumDescription(Types.Key.Password) + "/" + DateTime.Now.ToString("M/d/yyyy"));
                EmailTemplate emailTempObj = new EmailTemplate();
                SmtpMail smtpobj = new SmtpMail();
                EmailRepository mailrepo = new EmailRepository();
                emailTempObj = mailrepo.GetEmailById(Convert.ToInt32(Types.MailTemplateCofig.WelcomeAdmin));
                smtpobj = mailrepo.GetSmtpDetailsById(1);
                emailTempObj.Mail_Content = emailTempObj.Mail_Content.Replace("{Name}", userName);
                emailTempObj.Mail_Content = emailTempObj.Mail_Content.Replace("{Key}", eId);
                emailTempObj.Mail_To = acc2.MailID;
                //bool val = GenericClass.sendMail(emailTempObj, smtpobj);
                //if (val)
                //{
                //    flagMail = 1;
                //}
            }
            return new KeyValuePair<int, int>(flag, flagMail);
        }

        public List<Admin> GetAllAdmin()
        {
            AdminMapper objAccountDetailMapper = new AdminMapper();
            SqlParameter[] parameters = {                                           
                                           new SqlParameter("@Type","A")
                                       };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_Admin", parameters);
            using (reader)
            {
                return objAccountDetailMapper.Map(reader);
            }
        }
        public int AdminStatusChange(int? id)
        {
            int flag = 0;
            var admin = GetAllAdmin().Find(x => x.AdminID == id);
            if (admin.Status == false)
            {
                admin.Status = true;
            }
            else
            {
                admin.Status = false;
            }

            SqlParameter[] parameters = 
                {      
                new SqlParameter("@Status", admin.Status),
                new SqlParameter("@AdminID", id),            
                new SqlParameter("@Type","U")
                };
            flag = ExecuteNonQuery("Insert_Update_Fetch_Admin", parameters);
            return flag;
        }
        public int EditAdmin(Admin adm)
        {
            int flag = 0;
            if (adm.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(adm.File.FileName);
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    adm.ProfileImgName = adm.FirstName + "_" + D + m + y + "_" + DtTick + ext;

                    using (var binaryReader = new BinaryReader(adm.File.InputStream))
                    {
                        adm.ProfileImg = binaryReader.ReadBytes(adm.File.ContentLength);
                    }

                    //thumbnail storing
                    byte[] myByte = adm.ProfileImg;
                    Image i;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(myByte, 0, myByte.Length);
                        i = Image.FromStream(ms);
                    }
                    adm.ThumbnailProfileImg = GenericClass.imageToByteArray(i.GetThumbnailImage(100, 100, () => false, IntPtr.Zero));

                    //compress image
                    adm.ProfileImg = GenericClass.CompressSize(adm.ProfileImg);
                    //Saving to /ProfileImage Folder
                    path = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProfileImagePath"].ToString()), adm.ProfileImgName);
                    File.WriteAllBytes(path, adm.ProfileImg);
                }
            }
            SqlParameter[] parameters = 
                {                          
                    new SqlParameter("@AdminID", adm.AdminID),
                    new SqlParameter("@FirstName", adm.FirstName),
                    new SqlParameter("@LastName", adm.LastName),            
                    new SqlParameter("@MailID", adm.MailID),  
                    new SqlParameter("@ProfileImg", adm.ProfileImg),
                    new SqlParameter("@ProfileImgName", adm.ProfileImgName),
                    new SqlParameter("@ThumbnailProfileImg", adm.ThumbnailProfileImg),
                    new SqlParameter("@Type","M")
                };
            flag = ExecuteNonQuery("Insert_Update_Fetch_Admin", parameters);
            return flag;
        }
        public Admin GetAdminByID(int? id)
        {
            AdminMapper objadminmap = new AdminMapper();
            SqlParameter[] parameters = 
            {         
                 new SqlParameter("@AdminID", id),                  
                 new SqlParameter("@Type", "G")
            };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_Admin", parameters);
            using (reader)
            {
                return objadminmap.MapSingle(reader);
            }
        }
        public int DeleteAdmin(int? id)
        {
            int flag = 0;
            var admin = GetAllAdmin().Find(x => x.AdminID == id);
            admin.IsDeleted = true;
            SqlParameter[] parameters = 
                {      
                new SqlParameter("@Status", admin.IsDeleted),
                new SqlParameter("@AdminID", id),            
                new SqlParameter("@Type","D")
                };
            flag = ExecuteNonQuery("Insert_Update_Fetch_Admin", parameters);

            return flag;
        }
        public int ResetPassword(ResetPassword rp)
        {
            rp.New_Password = Cryptography.TDESEncryption(rp.New_Password, Types.GetEnumDescription(Types.Key.Password));
            int flag = 0;
            SqlParameter[] parameters = 
            { 
            new SqlParameter("@AdminID", rp.AdminID),
            new SqlParameter("@Password", rp.New_Password),
            new SqlParameter("@Type","R"),
            };
            flag = base.ExecuteNonQuery("Insert_Update_Fetch_Admin", parameters);
            return flag;
        }

        public List<Account> GetAllUserAccount()
        {
            AccountMapper objAccountDetailMapper = new AccountMapper();
            SqlParameter[] parameters = {                                           
                                           new SqlParameter("@Type","A")
                                       };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_Account", parameters);
            using (reader)
            {
                return objAccountDetailMapper.Map(reader);
            }
        }

        public int DeleteUser(int? id)
        {
            int flag = 0;
            SqlParameter[] parameters = 
                {                      
                new SqlParameter("@AccountId", id),            
                new SqlParameter("@Type","D")
                };
            flag = ExecuteNonQuery("Insert_Update_Fetch_Account", parameters);
            return flag;
        }
        public Account GetUserByID(int? id)
        {
            AccountMapper objAccountDetailMapper = new AccountMapper();
            SqlParameter[] parameters = 
            {         
                 new SqlParameter("@AccountId", id),                  
                 new SqlParameter("@Type", "G")
            };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_Account", parameters);
            using (reader)
            {
                return objAccountDetailMapper.MapSingle(reader);
            }
        }

        public int EditUser(Account act)
        {
            int flag = 0;
            if (act.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(act.File.FileName);
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    act.ProfileImgName = act.AccountName + "_" + D + m + y + "_" + DtTick + ext;

                    using (var binaryReader = new BinaryReader(act.File.InputStream))
                        act.ProfileImg = binaryReader.ReadBytes(act.File.ContentLength);
                    //thumbnail storing
                    byte[] myByte = act.ProfileImg;
                    Image i;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(myByte, 0, myByte.Length);
                        i = Image.FromStream(ms);
                    }
                    act.ThumbnailProfileImg = GenericClass.imageToByteArray(i.GetThumbnailImage(100, 100, () => false, IntPtr.Zero));

                    //compress image 
                    act.ProfileImg = GenericClass.CompressSize(act.ProfileImg);
                    //Saving to /ProfileImage Folder
                    path = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProfileImagePath"].ToString()), act.ProfileImgName);
                    File.WriteAllBytes(path, act.ProfileImg);
                }
            }
            SqlParameter[] parameters = 
                {                          
                    new SqlParameter("@AccountId", act.AccountId),
                    new SqlParameter("@AccountName", act.AccountName),                             
                    new SqlParameter("@AccountCode", act.RCode), 
                    new SqlParameter("@Phone", act.Phone),
                    new SqlParameter("@UserType", act.Type),
                    new SqlParameter("@ProfileImg", act.ProfileImg),
                    new SqlParameter("@Email", act.EmailId),
                    new SqlParameter("@ProfileImgName", act.ProfileImgName),
                    new SqlParameter("@ThumbnailProfileImg", act.ThumbnailProfileImg),
                    new SqlParameter("@Type","M")
                };
            flag = ExecuteNonQuery("Insert_Update_Fetch_Account", parameters);
            return flag;
        }

        public int UserStatusChange(int? id)
        {
            int flag = 0;
            var act = GetUserByID(id);
            if (act.Status == false)
            {
                act.Status = true;
            }
            else
            {
                act.Status = false;
            }

            SqlParameter[] parameters = 
                {      
                new SqlParameter("@Status", act.Status),
                new SqlParameter("@AccountId", id),            
                new SqlParameter("@Type","S")
                };
            flag = ExecuteNonQuery("Insert_Update_Fetch_Account", parameters);
            return flag;
        }
        public List<Admin> GetAdminDetailByUserId(Int32 id)
        {
            AdminMapper objAdminDetailMapper = new AdminMapper();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@AdminID",id),
                    new SqlParameter("@Type","G"),
            };

            IDataReader reader = base.GetReader("Insert_Update_Fetch_Admin", parameters);
            using (reader)
            {
                return objAdminDetailMapper.Map(reader);
            }
        }
    }
}
