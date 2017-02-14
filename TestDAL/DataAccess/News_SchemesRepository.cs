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
using ImageProcessor;
using System.Drawing;
namespace AdminDal.DataAccess
{
    internal class News_SchemesRepository:BaseRepository
    {
        Logging log = new Logging();
        public int NewsStatusChange(int? id)
        {
            int flag = 0;
            var act = GetnewsByID(id);
            if (act.Is_Active == false)
            {
                act.Is_Active = true;
            }
            else
            {
                act.Is_Active = false;
            }

            SqlParameter[] parameters = 
                {      
                new SqlParameter("@Is_Active", act.Is_Active),
                new SqlParameter("@News_Id", id),            
                new SqlParameter("@Type","C")
                };
            flag = ExecuteNonQuery("[Insert_Update_Fetch_News]", parameters);
            return flag;
        }
        public int AddNews(NewsModel news)
        {
            int flag = 0;
            try
            {
                news.Is_Deleted = false;
                news.Entered_Date = DateTime.Now;
                NewsModel obhScheme = new NewsModel();
                SqlParameter[] parameters = 
            {      
            new SqlParameter("@News_Title", news.News_Title),
            new SqlParameter("@News_Content", news.News_Content),
            new SqlParameter("@Admin_Id", news.Admin_Id),
            new SqlParameter("@Entered_Date", news.Entered_Date),
            new SqlParameter("@Is_Active", news.Is_Active),
            new SqlParameter("@Is_Deleted", news.Is_Deleted),
            new SqlParameter("@Type","I"),
            };
                flag = ExecuteNonQuery("Insert_Update_Fetch_News", parameters);
            }
            catch (Exception ex)
            {
                log.Logflatfile_Ex(ex);
                return flag;
            }
            return flag;
        }
        public int DeleteNews(int? id)
        {
            int flag = 0;
            try
            {
                NewsModel obhScheme = new NewsModel();
                SqlParameter[] parameters = 
                {      
                    new SqlParameter("@News_Id", id),
                    new SqlParameter("@Type","D"),
                };
                flag = ExecuteNonQuery("Insert_Update_Fetch_News", parameters);
            }
            catch (Exception ex)
            {
                log.Logflatfile_Ex(ex);
                return flag;
            }
            return flag;
        }
        public int EditNews(NewsModel news)
        {
            int flag = 0;
            try
            {
                news.Is_Deleted = false;
                NewsModel obhScheme = new NewsModel();
                SqlParameter[] parameters = 
                {      
                    new SqlParameter("@News_Id", news.News_Id),
                    new SqlParameter("@News_Title", news.News_Title),
                    new SqlParameter("@News_Content", news.News_Content),            
                    new SqlParameter("@Is_Active", news.Is_Active),            
                    new SqlParameter("@Type","U")
                };
                flag = ExecuteNonQuery("Insert_Update_Fetch_News", parameters);
            }
            catch (Exception ex)
            {
                log.Logflatfile_Ex(ex);
                return flag;
            }
            return flag;
        }
        public List<NewsModel> GetNews()
        {
            NewsMapper objnewsMapper = new NewsMapper();
            SqlParameter[] parameters = 
            {                                           
                 new SqlParameter("@Type", "F")
            };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_News", parameters);
            using (reader)
            {
                return objnewsMapper.Map(reader);
            }
        }
        public NewsModel GetnewsByID(int? id)
        {
            NewsMapper objnewsMapper = new NewsMapper();
            SqlParameter[] parameters = 
            {         
                 new SqlParameter("@News_Id", id),                  
                 new SqlParameter("@Type", "S")
            };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_News", parameters);
            using (reader)
            {
                return objnewsMapper.MapSingle(reader);
            }
        }
        public List<SchemeModel> GetScheme()
        {
            SchemeMapper objSchemeMapper = new SchemeMapper();
            SqlParameter[] parameters = {                                           
                                           new SqlParameter("@Type","F")
                                       };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_scheme", parameters);
            using (reader)
            {
                return objSchemeMapper.Map(reader);
            }
        }
        public int AddScheme(SchemeModel sch)
        {
            int flag = 0;
            try
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(sch.File.FileName);
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    //File name
                    sch.SchemeName = "Scheme_" + D + m + y + "_" + DtTick + ext;                    
                    byte[] myByte = sch.Scheme;
                    Image i;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(myByte, 0, myByte.Length);
                        i = Image.FromStream(ms);
                    }
                    sch.SchemeThumbnail = GenericClass.imageToByteArray(i.GetThumbnailImage(80, 80, () => false, IntPtr.Zero));

                    if (sch.UserType == @Types.GetEnumDescription(Types.UserType.Dealer))
                    {
                        path = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["DealerSchemePath"].ToString()), sch.SchemeName);//store the file in ~/Images folder
                        File.WriteAllBytes(path, sch.Scheme);
                    }
                    else
                    {
                        path = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["RetailerSchemePath"].ToString()), sch.SchemeName);
                        File.WriteAllBytes(path, sch.Scheme);
                    }

                    sch.Date = DateTime.Now;
                    sch.IsActive = true;
                    SqlParameter[] parameters = 
            {      
            new SqlParameter("@SchemeName", sch.SchemeName),
            new SqlParameter("@UserType", sch.UserType),
            new SqlParameter("@Date", sch.Date),
            new SqlParameter("@AdminID", sch.AdminID),
            new SqlParameter("@IsActive", sch.IsActive),
            new SqlParameter("@Scheme",sch.Scheme),
            new SqlParameter("@SchemeThumbnail",sch.SchemeThumbnail),
            new SqlParameter("@Type","I")
            };
                    flag = base.ExecuteNonQuery("Insert_Update_Fetch_scheme", parameters);
                }
            }
            catch (Exception ex)
            {
                log.Logflatfile_Ex(ex);
                return flag;
            }
            return flag;
        }
        public int DeleteScheme(int? id)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = 
                {      
                new SqlParameter("@SchemeId", id),            
                new SqlParameter("@Type","D")
                };
                flag = ExecuteNonQuery("Insert_Update_Fetch_scheme", parameters);
            }
            catch (Exception ex)
            {
                log.Logflatfile_Ex(ex);
                return flag;
            }
            return flag;
        }
        public int DefaultScheme(int? id)
        {
            int flag = 0;
            try
            {
                var scheme = GetScheme().Find(x => x.SchemeID == id);
                SqlParameter[] parameters = 
                {      
                new SqlParameter("@UserType", scheme.UserType),
                new SqlParameter("@SchemeId", id),            
                new SqlParameter("@Type","A")
                };
                flag = ExecuteNonQuery("Insert_Update_Fetch_scheme", parameters);
            }
            catch (Exception ex)
            {
                log.Logflatfile_Ex(ex);
                return flag;
            }
            return flag;
        }

        public SchemeModel GetSchemeByID(int? id)
        {
            SchemeMapper objSchemeMapper = new SchemeMapper();
            SqlParameter[] parameters = 
            {         
                 new SqlParameter("@SchemeId", id),                  
                 new SqlParameter("@Type", "S")
            };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_scheme", parameters);
            using (reader)
            {
                return objSchemeMapper.MapSingle(reader);
            }
        }
        public List<SchemeModel> GetSchemeByUserType(string Ut)
        {
            SchemeMapper objSchemeMapper = new SchemeMapper();
            SqlParameter[] parameters = {      
                                           new SqlParameter("@UserType", Ut),
                                           new SqlParameter("@Type","U")
                                       };
            IDataReader reader = base.GetReader("Insert_Update_Fetch_scheme", parameters);
            using (reader)
            {
                return objSchemeMapper.Map(reader);
            }            
        }
        public List<SchemeModel> GetSchemeWithAdmin(List<SchemeModel> schemes,List<Admin> admin)
        {
             List<SchemeModel> schem2 = new List<SchemeModel>();
             foreach (var scheme in schemes)
            {
                Admin Obj = admin.Where(a => a.AdminID == scheme.AdminID).FirstOrDefault();
                scheme.Admin = Obj;
                schem2.Add(scheme);
            }
             return schem2;
        }
        public List<NewsModel> GetNewsWithAdmin(List<NewsModel> news, List<Admin> admin)
        {
            List<NewsModel> news2 = new List<NewsModel>();
            foreach (var eachNews in news)
            {
                Admin Obj = admin.Where(a => a.AdminID == eachNews.Admin_Id).FirstOrDefault();
                eachNews.Admin = Obj;
                news2.Add(eachNews);
            }
            return news2;
        }
    }
}
