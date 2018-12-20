using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vstaskmgr.Bll;
using vstaskmgr.Model;

namespace vstaskmgr.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        // GET: api/Users
        [HttpGet]
        public User[] Get([FromQuery]string email, [FromQuery]string password)
        {
            return new User[] { new UserBll().GetLoginUser(email, password) };
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
