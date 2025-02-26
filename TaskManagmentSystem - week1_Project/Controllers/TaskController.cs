using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskMangmentSystem.DTOs;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
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

    [HttpPut("{taskId}")]
    public IActionResult UpdateTask(int taskId, [FromBody] TaskDto taskDto)
    {
        try
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            taskDto.Id = taskId; // Ensure the ID matches the URL
            var updatedTask = _taskService.UpdateTask(userId, taskDto);
            return Ok(updatedTask);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{taskId}")]
    public IActionResult DeleteTask(int taskId)
    {
        try
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _taskService.DeleteTask(userId, taskId);
            return Ok("Task deleted successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}