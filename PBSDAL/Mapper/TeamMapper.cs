using PBSDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBSDAL.Mapper
{
   public class TeamMapper
    {
        public List<Team> Map(IDataReader reader)
        {
            List<Team> tms = new List<Team>();
            while (reader.Read())
            {
                Team tm = new Team();
                tm.ID = Convert.ToInt32(reader["ID"].ToString());
                tm.Name = reader["Name"].ToString();
                tm.TeamCategory= reader["Category"].ToString();
                tm.Ar_Name = reader["Ar_Name"].ToString();                
                tm.ImagePath = reader["ImagePath"].ToString();
                tm.MyJob = reader["MyJob"].ToString();
                tm.ArMyJob = reader["ArMyJob"].ToString();
                tms.Add(tm);
            }
            return tms;
        }
    }
}
