using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vstaskmgr.Model;
using vstaskmgr.Services;

namespace vstaskmgr.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/Projects
        [HttpGet("find")]
        public IEnumerable<Project> FindProjectsByUserId([FromQuery]string members_like)
        {
            return _projectService.GetProjectList(members_like);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public Project Get(string id)
        {
            return _projectService.GetProjectById(id);
        }

        // POST: api/Projects
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Projects/5
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
