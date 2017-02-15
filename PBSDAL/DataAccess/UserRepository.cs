using PBSDAL.Entity;
using PBSDAL.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBSDAL.DataAccess
{
    public class UserRepository : BaseRepository
    {
        public List<User> GetUsers()
        {
            UserMapper objUsrMapper = new UserMapper();
            SqlParameter[] parameters = {                                           
                 new SqlParameter("@Type", "A")
            };
            IDataReader reader = base.GetReader("Manage_User", parameters);
            using (reader)
            {
                return objUsrMapper.Map(reader);
            }
        }
    }
}
