using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBSDAL.Entity;
using System.Data;

namespace PBSDAL.Mapper
{
    public class EventMapper
    {
        public List<Event> Map(IDataReader reader)
        {
            List<Event> evnts = new List<Event>();
            while (reader.Read())
            {
                Event evnt = new Event();
                evnt.ID = Convert.ToInt32(reader["ID"].ToString());
                evnt.Title = reader["Title"].ToString();
                evnt._Date = Convert.ToDateTime(reader["Event_Date"].ToString());
                evnt.Description = reader["Description"].ToString();
                evnt.Location = reader["Location"].ToString();
                evnt.Location_URL = reader["Location_URL"].ToString();
                evnt.Arabic_Title = reader["ArTitle"].ToString();
                evnt.Arabic_Description = reader["ArDescription"].ToString();
                evnt.Arabic_Location = reader["ArLocation"].ToString();
                evnt.Added_Date = Convert.ToDateTime(reader["Added_date"].ToString());
                evnt.IS_Active = Convert.ToBoolean(reader["Is_Active"].ToString());
                evnts.Add(evnt);
            }
            return evnts;
        }
    }
}