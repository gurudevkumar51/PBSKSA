using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDal.Entity;
using System.Data;

namespace AdminDal.Mapper
{
    public class NewsMapper : IMapper<List<NewsModel>>
    {
        public List<NewsModel> Map(IDataReader reader)
        {
            List<NewsModel> newses = new List<NewsModel>();
            while (reader.Read())
            {
                NewsModel news = new NewsModel();
                news.News_Id = Convert.ToInt32(reader["News_Id"].ToString());
                news.News_Title = reader["News_Title"].ToString();
                news.News_Content = reader["News_Content"].ToString();
                news.Admin_Id = Convert.ToInt32(reader["Admin_Id"].ToString());
                news.Entered_Date = Convert.ToDateTime(reader["Entered_Date"].ToString());
                news.Is_Active = Convert.ToBoolean(reader["Is_Active"].ToString());
                news.Is_Deleted = Convert.ToBoolean(reader["Is_Deleted"].ToString());               
                newses.Add(news);
            }
            return newses;
        }
        public NewsModel MapSingle(IDataReader reader)
        {
            NewsModel news = new NewsModel();
            while (reader.Read())
            {
                news.News_Id = Convert.ToInt32(reader["News_Id"].ToString());
                news.News_Title = reader["News_Title"].ToString();
                news.News_Content = reader["News_Content"].ToString();
                news.Admin_Id = Convert.ToInt32(reader["Admin_Id"].ToString());
                news.Entered_Date = Convert.ToDateTime(reader["Entered_Date"].ToString());
                news.Is_Active = Convert.ToBoolean(reader["Is_Active"].ToString());
                news.Is_Deleted = Convert.ToBoolean(reader["Is_Deleted"].ToString());
            }
            return news;
        }
    }
}
