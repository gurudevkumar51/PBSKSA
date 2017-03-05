using PBSDAL.Entity;
using PBSDAL.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PBSDAL.DataAccess
{
    class TeamRepository :BaseRepository
    {
        public int AddTeam(Team Tm)
        {
            int flag = 0;
            if (Tm.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(Tm.File.FileName);
                Tm.ImagePath = Tm.Name.Substring(0, 2) + "_" + D + m + y + "_" + DtTick + ext;
                path = Path.Combine(HttpContext.Current.Server.MapPath("~/imagesMVC/TeamImages/"), Tm.ImagePath);
                Tm.File.SaveAs(path);
            }
            try
            {               
                SqlParameter[] parameters = {      
                        new SqlParameter("@Name", Tm.Name),
                        new SqlParameter("@Ar_Name", Tm.Ar_Name),
                        new SqlParameter("@Designation", Tm.Designation),                        
                        new SqlParameter("@Ar_Designation", Tm.Ar_Designation),
                        new SqlParameter("@ImagePath",  Tm.ImagePath),    
                        new SqlParameter("@MyJob", Tm.MyJob),
                        new SqlParameter("@ArMyJob", Tm.ArMyJob),
                        new SqlParameter("@Secret", Tm.Secret),                        
                        new SqlParameter("@ArSecret", Tm.ArSecret),                        
                        new SqlParameter("@facts", Tm.facts),                        
                        new SqlParameter("@Arfacts", Tm.Arfacts),
                        new SqlParameter("@AnotherLife", Tm.AnotherLife),                        
                        new SqlParameter("@ArAnotherLife", Tm.ArAnotherLife),
                        new SqlParameter("@Quote", Tm.Quote),                        
                        new SqlParameter("@ArQuote", Tm.ArQuote),
                        new SqlParameter("@Type","B"),
                        };
                flag = ExecuteNonQuery("Manage_Team", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public List<Team> GetTeams()
        {
            TeamMapper objTmMapper = new TeamMapper();
            SqlParameter[] parameters = {                                           
                 new SqlParameter("@Type", "A")
            };
            IDataReader reader = base.GetReader("Manage_Team", parameters);
            using (reader)
            {
                return objTmMapper.Map(reader);
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
                flag = ExecuteNonQuery("Manage_Team", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public int UpdateTeam(Team Tm)
        {
            int flag = 0;
            if (Tm.File != null)
            {
                string time = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                var DtTick = DateTime.Now.Ticks.ToString();
                string[] sTime = time.Split('/').ToArray();
                var D = sTime[0];
                var m = sTime[1];
                var y = sTime[2];
                var path = "";
                var ext = Path.GetExtension(Tm.File.FileName);
                Tm.ImagePath = Tm.Name.Substring(0, 2) + "_" + D + m + y + "_" + DtTick + ext;
                path = Path.Combine(HttpContext.Current.Server.MapPath("~/imagesMVC/TeamImages/"), Tm.ImagePath);
                Tm.File.SaveAs(path);
            }
            try
            {
                SqlParameter[] parameters = {      
                        new SqlParameter("@ID", Tm.ID),
                        new SqlParameter("@Name", Tm.Name),
                        new SqlParameter("@Ar_Name", Tm.Ar_Name),
                        new SqlParameter("@Designation", Tm.Designation),                        
                        new SqlParameter("@Ar_Designation", Tm.Ar_Designation),
                        new SqlParameter("@ImagePath",  Tm.ImagePath),    
                        new SqlParameter("@MyJob", Tm.MyJob),
                        new SqlParameter("@ArMyJob", Tm.ArMyJob),
                        new SqlParameter("@Secret", Tm.Secret),                        
                        new SqlParameter("@ArSecret", Tm.ArSecret),                        
                        new SqlParameter("@facts", Tm.facts),                        
                        new SqlParameter("@Arfacts", Tm.Arfacts),
                        new SqlParameter("@AnotherLife", Tm.AnotherLife),                        
                        new SqlParameter("@ArAnotherLife", Tm.ArAnotherLife),
                        new SqlParameter("@Quote", Tm.Quote),                        
                        new SqlParameter("@ArQuote", Tm.ArQuote),
                        new SqlParameter("@Type","C"),
                        };
                flag = ExecuteNonQuery("Manage_Team", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }
    }
}
