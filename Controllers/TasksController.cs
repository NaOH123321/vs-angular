using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vstaskmgr.Model;
using vstaskmgr.Services;

namespace vstaskmgr.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return _taskService.Get();
        }

        // GET: api/Tasks/findAll
        [HttpGet("findAll")]
        public IEnumerable<Task> FindAllTaskLists([FromQuery]string ownerId)
        {
            return _taskService.GetByOwnerId(ownerId);
        }

        // GET: api/Tasks/find
        [HttpGet("find")]
        public IEnumerable<Task> FindTaskLists([FromQuery]string taskListId)
        {
            return _taskService.GetByTaskListId(taskListId);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public Task Get(string id)
        {
            return _taskService.Get(id);
        }

        // POST: api/Tasks
        [HttpPost]
        public Task Post([FromBody] Task task)
        {
            return _taskService.Create(task);
        }

        // Patch: api/Tasks/5
        [HttpPatch("{id}")]
        public Task Patch(string id, [FromBody] Task taskIn)
        {
            var task = _taskService.Get(id);

            if (task != null)
            {
                _taskService.Update(id, taskIn);
            }

            return Get(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var task = _taskService.Get(id);

            if (task != null)
            {
                _taskService.Remove(task.Id);
            }
        }
    }
}
