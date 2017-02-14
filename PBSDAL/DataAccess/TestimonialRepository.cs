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
    public class TestimonialRepository : BaseRepository
    {
        public int AddTestimonial(Testimonial tstmnl)
        {
            int flag = 0;
            if (tstmnl.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(tstmnl.File.FileName);
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    tstmnl.Image_Path = "_" + D + m + y + "_" + DtTick + ext;

                    using (var binaryReader = new BinaryReader(tstmnl.File.InputStream))
                        tstmnl.ByteImage = binaryReader.ReadBytes(tstmnl.File.ContentLength);
                    //thumbnail storing
                    byte[] myByte = tstmnl.ByteImage;
                    Image i;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(myByte, 0, myByte.Length);
                        i = Image.FromStream(ms);
                    }
                    tstmnl.ByteImageThumbnail = GenericClass.imageToByteArray(i.GetThumbnailImage(100, 100, () => false, IntPtr.Zero));

                    path = Path.Combine(HttpContext.Current.Server.MapPath("~/imagesMVC/TestimonialThumbnail/"), "thumb" + tstmnl.Image_Path);
                    File.WriteAllBytes(path, tstmnl.ByteImageThumbnail);
                    //compress image 
                    //portfolio.ByteImage = GenericClass.CompressSize(portfolio.ByteImage);
                    //Saving to /ProfileImage Folder
                    path = Path.Combine(HttpContext.Current.Server.MapPath("~/imagesMVC/Testimonial/"), tstmnl.Image_Path);
                    File.WriteAllBytes(path, tstmnl.ByteImage);
                }
            }
            try
            {
                SqlParameter[] parameters = {      
                        new SqlParameter("@Author", tstmnl.Author ),
                        new SqlParameter("@Author_Date", tstmnl.Author_Date  ),
                        new SqlParameter("@Image_Path", tstmnl.Image_Path),                        
                        new SqlParameter("@Resource_Link", tstmnl.Resource_Link),
                        new SqlParameter("@Description",  tstmnl.Description),
                        new SqlParameter("@Ar_Author", tstmnl.Ar_Author), 
                        new SqlParameter("@Ar_Description", tstmnl.Ar_Description ),
                        new SqlParameter("@Type","B"),
                        };
                flag = ExecuteNonQuery("Manage_Testimonial", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public List<Testimonial> GetTestimonial()
        {
            TestimonialMapper objtstmnlMapper = new TestimonialMapper();
            SqlParameter[] parameters = {                                           
                 new SqlParameter("@Type", "A")
            };
            IDataReader reader = base.GetReader("Manage_Testimonial", parameters);
            using (reader)
            {
                return objtstmnlMapper.Map(reader);
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
                        new SqlParameter("@Type", "D"),
                        };
                flag = ExecuteNonQuery("Manage_Testimonial", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public int UpdateTestimonial(Testimonial tstmnl)
        {
            int flag = 0;
            if (tstmnl.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(tstmnl.File.FileName);
                if (allowedExtensions.Contains(ext.ToLower()))
                {
                    tstmnl.Image_Path = "_" + D + m + y + "_" + DtTick + ext;

                    using (var binaryReader = new BinaryReader(tstmnl.File.InputStream))
                        tstmnl.ByteImage = binaryReader.ReadBytes(tstmnl.File.ContentLength);
                    //thumbnail storing
                    byte[] myByte = tstmnl.ByteImage;
                    Image i;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(myByte, 0, myByte.Length);
                        i = Image.FromStream(ms);
                    }
                    tstmnl.ByteImageThumbnail = GenericClass.imageToByteArray(i.GetThumbnailImage(100, 100, () => false, IntPtr.Zero));

                    path = Path.Combine(HttpContext.Current.Server.MapPath("~/imagesMVC/TestimonialThumbnail/"), "thumb" + tstmnl.Image_Path);
                    File.WriteAllBytes(path, tstmnl.ByteImageThumbnail);
                    //compress image 
                    //portfolio.ByteImage = GenericClass.CompressSize(portfolio.ByteImage);
                    //Saving to /ProfileImage Folder
                    path = Path.Combine(HttpContext.Current.Server.MapPath("~/imagesMVC/Testimonial/"), tstmnl.Image_Path);
                    File.WriteAllBytes(path, tstmnl.ByteImage);
                }
            }
            try
            {
                SqlParameter[] parameters = {
                        new SqlParameter("@ID", tstmnl.ID),
                        new SqlParameter("@Author", tstmnl.Author ),
                        new SqlParameter("@Author_Date", tstmnl.Author_Date  ),
                        new SqlParameter("@Image_Path", tstmnl.Image_Path),                        
                        new SqlParameter("@Resource_Link", tstmnl.Resource_Link),
                        new SqlParameter("@Description",  tstmnl.Description),
                        new SqlParameter("@Ar_Author", tstmnl.Ar_Author), 
                        new SqlParameter("@Ar_Description", tstmnl.Ar_Description ),
                        new SqlParameter("@Type","C"),
                        };
                flag = ExecuteNonQuery("Manage_Testimonial", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }
    }
}
