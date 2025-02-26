
using TaskMangmentSystem.DTOs;

namespace TaskManagementSystem.Services;
public interface ITaskService
{
    List<TaskDto> GetUserTasks(int userId);
    TaskDto CreateTask(int userId, TaskDto taskDto);
}