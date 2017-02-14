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
    public class QuoteRepository : BaseRepository
    {
        public int AddQuote(Quotes Qts)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = {      
                        new SqlParameter("@Quote", Qts.Quote),
                        new SqlParameter("@Author", Qts.Author  ),
                        new SqlParameter("@ArQuote", Qts.AR_Quote),                        
                        new SqlParameter("@ArAuthor", Qts.AR_Author),                        
                        new SqlParameter("@Is_Active", true ),
                        new SqlParameter("@Type","B"),
                        };
                flag = ExecuteNonQuery("Manage_Quotes", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public List<Quotes> GetQuotes()
        {
            QuotesMapper objQtsMapper = new QuotesMapper();
            SqlParameter[] parameters = {                                           
                 new SqlParameter("@Type", "A")
            };
            IDataReader reader = base.GetReader("Manage_Quotes", parameters);
            using (reader)
            {
                return objQtsMapper.Map(reader);
            }
        }

        public int ChangeQuoteStatus(int id, Boolean IsActive)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = {
                        new SqlParameter("@ID", id),
                        new SqlParameter("@Is_Active", IsActive),
                        new SqlParameter("@Type","D"),
                        };
                flag = ExecuteNonQuery("Manage_Quotes", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }

        public int UpdateQuote(Quotes Qts)
        {
            int flag = 0;
            try
            {
                SqlParameter[] parameters = {
                        new SqlParameter("@ID", Qts.ID),
                        new SqlParameter("@Quote", Qts.Quote),
                        new SqlParameter("@Author", Qts.Author  ),
                        new SqlParameter("@ArQuote", Qts.AR_Quote),                        
                        new SqlParameter("@ArAuthor", Qts.AR_Author), 
                        new SqlParameter("@Type","C"),
                        };
                flag = ExecuteNonQuery("Manage_Quotes", parameters);
            }
            catch (Exception ex)
            {
                return flag;
            }
            return flag;
        }
    }
}
