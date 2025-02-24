using Microsoft.AspNetCore.Mvc;
using TaskManagerDemo.Core;

namespace TaskManagerDemo.Application
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly CreateTask _createTask;
        private readonly ListTasks _listTasks;

        public TaskController(CreateTask createTask, ListTasks listTasks)
        {
            _createTask = createTask;
            _listTasks = listTasks;
        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskRequest request)
        {
            var task = _createTask.Execute(request.Title);
            return Ok(task);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _listTasks.Execute();
            return Ok(tasks);
        }
    }

    public class TaskRequest
    {
        public string Title { get; set; }
    }
}