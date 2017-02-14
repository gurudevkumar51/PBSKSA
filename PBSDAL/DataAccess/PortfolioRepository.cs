using PBSDAL.Common;
using PBSDAL.Entity;
using PBSDAL.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PBSDAL.DataAccess
{
    public class PortfolioRepository : BaseRepository
    {
        public int AddPortfolio(Portfolio portfolio)
        {
            int flag = 0;
            if (portfolio.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(portfolio.File.FileName);
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    portfolio.Image_Path = "_" + D + m + y + "_" + DtTick + ext;

                    using (var binaryReader = new BinaryReader(portfolio.File.InputStream))
                        portfolio.ByteImage = binaryReader.ReadBytes(portfolio.File.ContentLength);
                    //thumbnail storing
                    byte[] myByte = portfolio.ByteImage;
                    Image i;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(myByte, 0, myByte.Length);
                        i = Image.FromStream(ms);
                    }
                    portfolio.ByteImageThumbnail = GenericClass.imageToByteArray(i.GetThumbnailImage(100, 100, () => false, IntPtr.Zero));

                    path = Path.Combine(HttpContext.Current.Server.MapPath("~/imagesMVC/PortfolioThumbnail/"), "thumb" + portfolio.Image_Path);
                    File.WriteAllBytes(path, portfolio.ByteImageThumbnail);
                    //compress image 
                    //portfolio.ByteImage = GenericClass.CompressSize(portfolio.ByteImage);
                    //Saving to /ProfileImage Folder
                    path = Path.Combine(HttpContext.Current.Server.MapPath("~/imagesMVC/Portfolio/"), portfolio.Image_Path);
                    File.WriteAllBytes(path, portfolio.ByteImage);
                }
            }
            try
            {
                SqlParameter[] parameters = {      
                        new SqlParameter("@Title", portfolio.Title),
                        new SqlParameter("@Date", portfolio._Date  ),
                        new SqlParameter("@Image_Path", portfolio.Image_Path),                        
                        new SqlParameter("@Location_Name", portfolio.Location_Name),
                        new SqlParameter("@AR_Title",  portfolio.AR_Title),
                        new SqlParameter("@AR_Location_Name", portfolio.AR_Location_Name), 
                        new SqlParameter("@Is_Active", true ),
                        new SqlParameter("@Type","B"),
                        };
                flag = ExecuteNonQuery("Manage_PortFolio", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public List<Portfolio> GetPortfolio()
        {
            PortfolioMapper objPortFolioMapper = new PortfolioMapper();
            SqlParameter[] parameters = {                                           
                 new SqlParameter("@Type", "A")
            };
            IDataReader reader = base.GetReader("Manage_PortFolio", parameters);
            using (reader)
            {
                return objPortFolioMapper.Map(reader);
            }
        }

        public int ChangeStatus(int id, Boolean IsActive)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = {
                        new SqlParameter("@ID", id),
                        new SqlParameter("@Is_Active", IsActive),
                        new SqlParameter("@Type","D"),
                        };
                flag = ExecuteNonQuery("Manage_PortFolio", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public int UpdatePortfolio(Portfolio portfolio)
        {
            int flag = 0;
            if (portfolio.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(portfolio.File.FileName);
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    portfolio.Image_Path = "_" + D + m + y + "_" + DtTick + ext;

                    using (var binaryReader = new BinaryReader(portfolio.File.InputStream))
                        portfolio.ByteImage = binaryReader.ReadBytes(portfolio.File.ContentLength);
                    //thumbnail storing
                    byte[] myByte = portfolio.ByteImage;
                    Image i;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(myByte, 0, myByte.Length);
                        i = Image.FromStream(ms);
                    }
                    portfolio.ByteImageThumbnail = GenericClass.imageToByteArray(i.GetThumbnailImage(100, 100, () => false, IntPtr.Zero));

                    path = Path.Combine(HttpContext.Current.Server.MapPath("~/imagesMVC/PortfolioThumbnail/"), "thumb" + portfolio.Image_Path);
                    File.WriteAllBytes(path, portfolio.ByteImageThumbnail);
                    //compress image 
                    //portfolio.ByteImage = GenericClass.CompressSize(portfolio.ByteImage);
                    //Saving to /ProfileImage Folder
                    path = Path.Combine(HttpContext.Current.Server.MapPath("~/imagesMVC/Portfolio/"), portfolio.Image_Path);
                    File.WriteAllBytes(path, portfolio.ByteImage);
                }
            }

            try
            {
                SqlParameter[] parameters = {
                        new SqlParameter("@ID", portfolio.ID),
                        new SqlParameter("@Title", portfolio.Title),
                        new SqlParameter("@Date", portfolio._Date  ),
                        new SqlParameter("@Image_Path", portfolio.Image_Path),                        
                        new SqlParameter("@Location_Name", portfolio.Location_Name),
                        new SqlParameter("@AR_Title",  portfolio.AR_Title),
                        new SqlParameter("@AR_Location_Name", portfolio.AR_Location_Name), 
                        new SqlParameter("@Type","C"),
                        };
                flag = ExecuteNonQuery("Manage_PortFolio", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }
    }
}
