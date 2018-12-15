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
    public class UsersController : Controller
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return null;
            // return new ProjectBll().GetProjectList();
        }

        // GET api/Quotes/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return null;
        }
    }
}
