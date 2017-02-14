using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBSDAL.Entity;
using System.Data;

namespace PBSDAL.Mapper
{
    class QuotesMapper
    {
        public List<Quotes> Map(IDataReader reader)
        {
            List<Quotes> quotes = new List<Quotes>();
            while (reader.Read())
            {
                Quotes quote = new Quotes();
                quote.ID = Convert.ToInt32(reader["ID"].ToString());
                quote.Quote = reader["Quote"].ToString();
                quote.Author = reader["Author"].ToString();
                quote.AR_Quote = reader["ArQuote"].ToString();
                quote.AR_Author = reader["ArAuthor"].ToString();   
                quote.Added_Date = Convert.ToDateTime(reader["Added_Date"].ToString());
                quote.Is_Active = Convert.ToBoolean(reader["Is_Active"].ToString());
                quotes.Add(quote);
            }
            return quotes;
        }
    }
}    