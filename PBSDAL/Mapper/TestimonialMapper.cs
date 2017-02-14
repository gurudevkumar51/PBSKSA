using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBSDAL.Entity;
using System.Data;

namespace PBSDAL.Mapper
{
    public class TestimonialMapper
    {
        public List<Testimonial> Map(IDataReader reader)
        {
            List<Testimonial> tstmnls = new List<Testimonial>();
            while (reader.Read())
            {
                Testimonial tstmnl = new Testimonial();
                tstmnl.ID = Convert.ToInt32(reader["ID"].ToString());
                tstmnl.Author_Date = Convert.ToDateTime(reader["Author_Date"].ToString());
                tstmnl.Author = reader["Author"].ToString();
                tstmnl.Ar_Author = reader["Ar_Author"].ToString();
                tstmnl.Image_Path = reader["Image_path"].ToString();
                tstmnl.Resource_Link = reader["Resource_Link"].ToString();
                tstmnl.Description = reader["Description"].ToString();
                tstmnl.Ar_Description = reader["Ar_Description"].ToString();
                tstmnl.Added_Date = Convert.ToDateTime(reader["Added_Date"].ToString());
                tstmnl.Is_Active = Convert.ToBoolean(reader["Is_Active"].ToString());
                tstmnl.thumbnailPath = "thumb" + reader["Image_path"].ToString();
                tstmnls.Add(tstmnl);
            }
            return tstmnls;
        }
    }
}        