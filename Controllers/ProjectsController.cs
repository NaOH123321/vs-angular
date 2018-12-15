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
    public class ProjectsController : Controller
    {
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return new ProjectBll().GetProjectList();
        }

        // GET api/Quotes/5
        //    [HttpGet("{id}")]
        // public Project Get(string id)
        // {
        //     var qList = new ProjectBll().GetProjectList();
        //     Random r = new Random();
        //     int n = r.Next(new ProjectBll().GetQuoteList().Count);
        //     return qList.ElementAt(n);
        // }
    }
}
