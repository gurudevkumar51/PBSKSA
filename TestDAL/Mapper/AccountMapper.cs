using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDal.Entity;
using System.Data;

namespace AdminDal.Mapper
{
    class AccountMapper
    {
        public List<Account> Map(IDataReader reader)
        {
            List<Account> accounts = new List<Account>();
            while (reader.Read())
            {
                Account account = new Account();
                account.AccountId = Convert.ToInt32(reader["AccountId"].ToString());
                account.AccountName = reader["AccountName"].ToString();
                account.RCode = reader["AccountCode"].ToString();
                account.Phone = reader["Phone"].ToString();
                account.Type = reader["UserType"].ToString();
                account.Password = reader["Password"].ToString();
                account.IsReset = Convert.ToBoolean(reader["IsReset"]);
                account.Status = Convert.ToBoolean(reader["Status"]);
                account.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                account.EmailId = reader["Email"].ToString();
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

        public Account MapSingle(IDataReader reader)
        {
            Account account = new Account();
            while (reader.Read())
            {
                account.AccountId = Convert.ToInt32(reader["AccountId"].ToString());
                account.AccountName = reader["AccountName"].ToString();
                account.RCode = reader["AccountCode"].ToString();
                account.Phone = reader["Phone"].ToString();
                account.Type = reader["UserType"].ToString();
                account.Password = reader["Password"].ToString();
                account.IsReset = Convert.ToBoolean(reader["IsReset"].ToString());
                account.Status = Convert.ToBoolean(reader["Status"].ToString());
                account.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                account.EmailId = reader["Email"].ToString();
                if (reader["ProfileImg"] != DBNull.Value)
                {
                    account.ProfileImg = (byte[])reader["ProfileImg"];
                }
                account.ProfileImgName = reader["ProfileImgName"].ToString();
                if (reader["ThumbnailProfileImg"] != DBNull.Value)
                {
                    account.ThumbnailProfileImg = (byte[])reader["ThumbnailProfileImg"];
                }
            }
            return account;
        }
    }
}
