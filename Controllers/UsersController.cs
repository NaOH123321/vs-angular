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
            return _userService.Get();
        }

        // GET: api/Users/search
        [HttpGet("search")]
        public IEnumerable<User> FindUsersByEmail([FromQuery]string email)
        {
            return _userService.GetByEmail(email);
        }

        // GET: api/Users/find
        [HttpGet("find")]
        public IEnumerable<User> FindUsersByProjectId([FromQuery]string projectIds_like)
        {
            return _userService.GetByProjectId(projectIds_like);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _userService.Get(id);
        }

        // POST: api/Users
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _userService.Create(user);
        }

        // Patch: api/Users/5
        [HttpPatch("{id}")]
        public User Patch(string id, [FromBody] User userIn)
        {
            var task = _userService.Get(id);

            if (task != null)
            {
                _userService.Update(id, userIn);
            }

            return Get(id);
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
