using System.Collections.Generic;
using vstaskmgr.DBUtility;
using vstaskmgr.Model;

namespace vstaskmgr.Services
{
    public class QuoteService
    {
        private readonly string _collectrionName = "quote";
        private readonly MongoDbHelper _mongoDbHelper;

        public QuoteService(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
        }

        public List<Quote> Get()
        {
            return _mongoDbHelper.GetAll<Quote>(_collectrionName);
        }
    }
}
