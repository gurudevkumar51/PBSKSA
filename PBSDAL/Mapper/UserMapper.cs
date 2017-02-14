using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBSDAL.Entity;
using System.Data;

namespace PBSDAL.Mapper
{
    public class UserMapper
    {
        public List<User> Map(IDataReader reader)
        {
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.ID = Convert.ToInt32(reader["ID"].ToString());
                
                user.Name = reader["Name"].ToString();
                user.Username = reader["UserName"].ToString();
                user.Email = reader["Email"].ToString();
                user.Password = reader["Password"].ToString();
                user.Image_Path = reader["Description"].ToString();
                user.Phone = reader["ImagePath"].ToString();
                users.Add(user);
            }
            return users;
        }
    }
}