using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vstaskmgr.Model;
using vstaskmgr.BLL;

namespace vstaskmgr.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return new QuotesBLL().GetQuoteList();
        }

        // GET api/Quotes/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            var qList = new QuotesBLL().GetQuoteList();
            Random r = new Random();
            int n = r.Next(new QuotesBLL().GetQuoteList().Count);
            return qList.ElementAt(n);
        }
    }
}
