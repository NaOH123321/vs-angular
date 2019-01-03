using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using vstaskmgr.Model;
using vstaskmgr.Services;

namespace vstaskmgr.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        private readonly QuoteService _quoteService;

        public QuotesController(QuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("Getpp")]
        public ActionResult<IEnumerable<Quote>> Getgg(int id)
        {
            if (!ModelState.IsValid)
            {
                ObjectResult result = new ObjectResult(ModelState);
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Value = new ReturnMessage() { StatusCode = 10000, Message = "sdsdsadsadsads" };
                return result;
            }
            return _quoteService.Get();
        }

        // GET api/Quotes/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            var qList = _quoteService.Get();
            Random r = new Random();
            int n = r.Next(_quoteService.Get().Count);
            return qList.ElementAt(n);
        }

        private class ReturnMessage
        {
            public ReturnMessage()
            {
            }

            public object StatusCode { get; set; }
            public object Message { get; set; }
        }
    }
}
