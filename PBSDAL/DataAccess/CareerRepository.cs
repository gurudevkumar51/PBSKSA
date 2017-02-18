using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBSDAL.Entity;
using System.Data.SqlClient;
using PBSDAL.Mapper;
using System.IO;
using System.Web;
using PBSDAL.Common;
using System.Data;

namespace PBSDAL.DataAccess
{
    class CareerRepository : BaseRepository
    {
        public int AddCareer(Career crr)
        {
            int flag = 0;
            if (crr.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(crr.File.FileName);
                crr.ResumePath = "Resume_" + D + m + y + "_" + DtTick + ext;
                path = Path.Combine(HttpContext.Current.Server.MapPath("~/Resume/"), crr.ResumePath);
                crr.File.SaveAs(path);
            }
            try
            { 
                SqlParameter[] parameters = {      
                        new SqlParameter("@PostApplied", crr.Designation),
                        new SqlParameter("@FullName", crr.FullName),
                        new SqlParameter("@PhoneNumber", crr.PhoneNo),                        
                        new SqlParameter("@EmailID", crr.EmailID),
                        new SqlParameter("@ResumePath",  crr.ResumePath),                        
                        new SqlParameter("@Type","B"),
                        };
                flag = ExecuteNonQuery("Manage_Career", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public List<Career> GetResumes()
        {
            CareerMapper objCrrMapper = new CareerMapper();
            SqlParameter[] parameters = {                                           
                 new SqlParameter("@Type", "A")
            };
            IDataReader reader = base.GetReader("Manage_Career", parameters);
            using (reader)
            {
                return objCrrMapper.Map(reader);
            }
        }
    }
}
