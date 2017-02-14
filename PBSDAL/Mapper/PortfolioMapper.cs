using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBSDAL.Entity;
using System.Data;

namespace PBSDAL.Mapper
{
    public class PortfolioMapper
    {
        public List<Portfolio> Map(IDataReader reader)
        {
            List<Portfolio> portfolios = new List<Portfolio>();
            while (reader.Read())
            {
                Portfolio portfolio = new Portfolio();
                portfolio.ID = Convert.ToInt32(reader["ID"].ToString());
                portfolio.Title = reader["Title"].ToString();
                portfolio.AR_Title = reader["AR_Title"].ToString();
                portfolio.AR_Location_Name = reader["AR_Location_Name"].ToString();
                portfolio._Date = Convert.ToDateTime(reader["Date"].ToString());
                portfolio.Image_Path = reader["Image_Path"].ToString();
                portfolio.Location_Name = reader["Location_Name"].ToString();
                portfolio.Added_Date = Convert.ToDateTime(reader["Added_Date"].ToString());
                portfolio.Is_Active = Convert.ToBoolean(reader["Is_Active"].ToString());
                portfolio.thumbnailPath = "thumb" + reader["Image_Path"].ToString();
                portfolios.Add(portfolio);
            }
            return portfolios;
        }
    }
}
