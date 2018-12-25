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
    public class TaskListsController : Controller
    {
        private readonly TaskListService _taskListService;

        public TaskListsController(TaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        // GET: api/TaskLists
        [HttpGet]
        public IEnumerable<TaskList> Get()
        {
            return _taskListService.Get();
        }

        // GET: api/Users
        [HttpGet("find")]
        public IEnumerable<TaskList> FindTaskLists([FromQuery]string projectId)
        {
            return _taskListService.GetByProjectId(projectId);
        }

        // GET: api/TaskLists/5
        [HttpGet("{id}")]
        public TaskList Get(string id)
        {
            return _taskListService.Get(id);
        }

        // POST: api/TaskLists
        [HttpPost]
        public TaskList Post([FromBody] TaskList taskList)
        {
            return _taskListService.Create(taskList);
        }

        // Patch: api/TaskLists/5
        [HttpPatch("{id}")]
        public TaskList Patch(string id, [FromBody] TaskList taskListIn)
        {
            var taskList = _taskListService.Get(id);

            if (taskList != null)
            {
                _taskListService.Update(id, taskListIn);
            }

            return Get(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var taskList = _taskListService.Get(id);

            if (taskList != null)
            {
                _taskListService.Remove(taskList.Id);
            }
        }
    }
}
