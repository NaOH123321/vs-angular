using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vstaskmgr.Model;
using vstaskmgr.Services;

namespace vstaskmgr.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users/login
        [HttpGet("login")]
        public IEnumerable<User> Login([FromQuery]string email, [FromQuery]string password)
        {
            return new User[] { _userService.GetLoginUser(email, password) };
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _userService.GetProjectById(id);
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
