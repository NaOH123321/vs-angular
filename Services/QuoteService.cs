using System.Collections.Generic;
using vstaskmgr.DBUtility;
using vstaskmgr.Model;

namespace vstaskmgr.Services
{
    public class QuoteService
    {
        private readonly MongoDbHelper _mongoDbHelper;

        public QuoteService(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
        }

        public List<Quote> GetQuoteList()
        {
            List<Quote> quoteArray = _mongoDbHelper.GetAll<Quote>("quote");
            return quoteArray;
        }
    }
}
