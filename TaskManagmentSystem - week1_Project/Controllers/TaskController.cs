using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskMangmentSystem.DTOs;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize] // Requires JWT token
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService) => _taskService = taskService;

    [HttpGet]
    public IActionResult GetTasks()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var tasks = _taskService.GetUserTasks(userId);
        return Ok(tasks);
    }

    [HttpPost]
    public IActionResult CreateTask([FromBody] TaskDto taskDto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var task = _taskService.CreateTask(userId, taskDto);
        return Ok(task);
    }
}