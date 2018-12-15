using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vstaskmgr.Model;
using vstaskmgr.Bll;

namespace vstaskmgr.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return new QuoteBll().GetQuoteList();
        }

        // GET api/Quotes/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            var qList = new QuoteBll().GetQuoteList();
            Random r = new Random();
            int n = r.Next(new QuoteBll().GetQuoteList().Count);
            return qList.ElementAt(n);
        }
    }
}
