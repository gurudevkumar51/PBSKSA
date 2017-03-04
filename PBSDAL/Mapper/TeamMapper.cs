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
                tm.Ar_Name = reader["Ar_Name"].ToString();
                tm.Designation = reader["Designation"].ToString();
                tm.Ar_Designation = reader["Ar_Designation"].ToString();
                tm.ImagePath = reader["ImagePath"].ToString();
                tm.Skills = reader["Skills"].ToString();
                tm.Ar_Skills = reader["Ar_Skills"].ToString();
                tm.Expertise = reader["Expertise"].ToString();
                tm.Ar_Expertise = reader["Ar_Expertise"].ToString();
                tms.Add(tm);
            }
            return tms;
        }
    }
}
