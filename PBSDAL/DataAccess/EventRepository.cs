using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBSDAL.Entity;
using PBSDAL.Mapper;
using System.Data.SqlClient;
using System.Data;

namespace PBSDAL.DataAccess
{
    public class EventRepository : BaseRepository
    {
        public int AddEvent(Event evnt)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = {      
                        new SqlParameter("@Title", evnt.Title),
                        new SqlParameter("@Event_Date", evnt._Date  ),
                        new SqlParameter("@Description", evnt.Description),                        
                        new SqlParameter("@Location_Url", evnt.Location_URL),
                        new SqlParameter("@Location",  evnt.Location),
                        new SqlParameter("@ArTitle", evnt.Arabic_Title),                        
                        new SqlParameter("@ArDescription", evnt.Arabic_Description),
                        new SqlParameter("@ArLocation",  evnt.Arabic_Location),
                        new SqlParameter("@Is_Active", true ),
                        new SqlParameter("@Type","B"),
                        };
                flag = ExecuteNonQuery("Manage_Event", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }
         
        public List<Event> GetEvnts()
        {
            EventMapper objEvntMapper = new EventMapper();
            SqlParameter[] parameters = {                                           
                 new SqlParameter("@Type", "A")
            };
            IDataReader reader = base.GetReader("Manage_Event", parameters);
            using (reader)
            {
                return objEvntMapper.Map(reader);
            }
        }

        public int ChangeStatus(int id,Boolean IsActive)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = {
                        new SqlParameter("@ID", id),
                        new SqlParameter("@Is_Active", IsActive),
                        new SqlParameter("@Type","D"),
                        };
                flag = ExecuteNonQuery("Manage_Event", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public int UpdateEvent(Event evnt)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = {
                        new SqlParameter("@ID", evnt.ID),
                        new SqlParameter("@Title", evnt.Title),
                        new SqlParameter("@Event_Date", evnt._Date  ),
                        new SqlParameter("@Description", evnt.Description),                        
                        new SqlParameter("@Location_Url", evnt.Location_URL),
                        new SqlParameter("@Location",  evnt.Location),
                        new SqlParameter("@ArTitle", evnt.Arabic_Title),                        
                        new SqlParameter("@ArDescription", evnt.Arabic_Description),
                        new SqlParameter("@ArLocation",  evnt.Arabic_Location),
                        new SqlParameter("@Type","C"),
                        };
                flag = ExecuteNonQuery("Manage_Event", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }
    }
}