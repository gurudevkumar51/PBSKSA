using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDal.Entity;
using System.Data;

namespace AdminDal.Mapper
{
    public class SchemeMapper : IMapper<List<SchemeModel>>
    {
        public List<SchemeModel> Map(IDataReader reader)
        {
            List<SchemeModel> schemes = new List<SchemeModel>();
            while (reader.Read())
            {
                SchemeModel scheme = new SchemeModel();
                scheme.SchemeID = Convert.ToInt32(reader["SchemeID"].ToString());
                scheme.SchemeName = reader["SchemeName"].ToString();
                scheme.AdminID = Convert.ToInt32(reader["AdminID"]);
                scheme.UserType = reader["UserType"].ToString();
                scheme.Date = Convert.ToDateTime(reader["Date"]);
                scheme.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["Scheme"] != DBNull.Value)
                {
                    scheme.Scheme = (byte[])reader["Scheme"];
                }
                if (reader["SchemeThumbnail"] != DBNull.Value)
                {
                    scheme.SchemeThumbnail = (byte[])reader["SchemeThumbnail"];
                }
                schemes.Add(scheme);
            }
            return schemes;
        }
        public SchemeModel MapSingle(IDataReader reader)
        {
            SchemeModel scheme = new SchemeModel();
            while (reader.Read())
            {
                scheme.SchemeID = Convert.ToInt32(reader["SchemeID"].ToString());
                scheme.SchemeName = reader["SchemeName"].ToString();
                scheme.AdminID = Convert.ToInt32(reader["AdminID"]);
                scheme.UserType = reader["UserType"].ToString();
                scheme.Date = Convert.ToDateTime(reader["Date"]);
                scheme.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["Scheme"] != DBNull.Value)
                {
                    scheme.Scheme = (byte[])reader["Scheme"];
                }
                if (reader["SchemeThumbnail"] != DBNull.Value)
                {
                    scheme.SchemeThumbnail = (byte[])reader["SchemeThumbnail"];
                }
            }
            return scheme;
        }
    }
}
