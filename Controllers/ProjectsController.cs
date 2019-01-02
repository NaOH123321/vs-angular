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
    public class ProjectsController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/Projects
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return _projectService.Get();
        }

        // GET: api/Projects/find
        [HttpGet("find")]
        public IEnumerable<Project> FindProjectsByUserId([FromQuery]string members_like)
        {
            return _projectService.GetByUserId(members_like);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public Project Get(string id)
        {
            return _projectService.Get(id);
        }

        // POST: api/Projects
        [HttpPost]
        public Project Post([FromBody] Project project)
        {
            return _projectService.Create(project);
        }

        // Patch: api/Projects/5
        [HttpPatch("{id}")]
        public Project Patch(string id, [FromBody] Project projectIn)
        {
            var project = _projectService.Get(id);

            if (project != null)
            {
                _projectService.Update(id, projectIn);
            }

            return Get(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var project = _projectService.Get(id);

            if (project != null)
            {
                _projectService.Remove(project.Id);
            }
        }
    }
}
