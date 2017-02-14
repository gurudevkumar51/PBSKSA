using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDal.Entity;
using System.Data;

namespace AdminDal.Mapper
{
    public class AdminMapper : IMapper<List<Admin>>
    {
        public List<Admin> Map(IDataReader reader)
        {
            List<Admin> accounts = new List<Admin>();
            while (reader.Read())
            {
                Admin account = new Admin();
                account.AdminID = Convert.ToInt32(reader["AdminID"].ToString());
                account.MailID = reader["MailID"].ToString();
                account.Password = reader["Password"].ToString();
                account.FirstName = reader["FirstName"].ToString();
                account.LastName = reader["LastName"].ToString();
                account.Status = Convert.ToBoolean(reader["Status"]);
                account.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                account.AdminType = reader["AdminType"].ToString();
                if (reader["ProfileImg"] != DBNull.Value)
                {
                    account.ProfileImg = (byte[])reader["ProfileImg"];
                }
                account.ProfileImgName = reader["ProfileImgName"].ToString();
                if (reader["ThumbnailProfileImg"] != DBNull.Value)
                {
                    account.ThumbnailProfileImg = (byte[])reader["ThumbnailProfileImg"];
                }
                accounts.Add(account);
            }
            return accounts;
        }

        public Admin MapSingle(IDataReader reader)
        {
            Admin adm = new Admin();
            while (reader.Read())
            {
                adm.AdminID = Convert.ToInt32(reader["AdminID"].ToString());
                adm.MailID = reader["MailID"].ToString();
                adm.Password = reader["Password"].ToString();
                adm.FirstName = reader["FirstName"].ToString();
                adm.LastName = reader["LastName"].ToString();
                adm.Status = Convert.ToBoolean(reader["Status"]);
                adm.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                adm.AdminType = reader["AdminType"].ToString();
                if (reader["ProfileImg"] != DBNull.Value)
                {
                    adm.ProfileImg = (byte[])reader["ProfileImg"];
                }
                adm.ProfileImgName = reader["ProfileImgName"].ToString();
                if (reader["ThumbnailProfileImg"] != DBNull.Value)
                {
                    adm.ThumbnailProfileImg = (byte[])reader["ThumbnailProfileImg"];
                }
            }
            return adm;
        }
    }
}
