using PBSDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBSDAL.Mapper
{
    public class CareerMapper
    {
        public List<Career> Map(IDataReader reader)
        {
            List<Career> crrs = new List<Career>();
            while (reader.Read())
            {
                Career crr = new Career();
                crr.ID = Convert.ToInt32(reader["ID"].ToString());
                crr.FullName = reader["FullName"].ToString();
                crr.PhoneNo = reader["PhoneNo"].ToString();
                crr.EmailID = reader["EmailID"].ToString();
                crr.ResumePath = reader["Resume_Path"].ToString();
                crr.Designation = reader["PostApplied"].ToString();
                crrs.Add(crr);
            }
            return crrs;
        }
    }
}