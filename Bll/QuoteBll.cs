using System.Collections.Generic;
using vstaskmgr.Model;

namespace vstaskmgr.Bll
{
    public class QuoteBll
    {
        public List<Quote> GetQuoteList()
        {
            List<Quote> quoteArray = DBUtility.MongoDbHelper.GetAll<Quote>("quote");
            return quoteArray;
        }
    }
}
