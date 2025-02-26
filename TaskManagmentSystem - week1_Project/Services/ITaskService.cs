
using TaskMangmentSystem.DTOs;

namespace TaskManagementSystem.Services;
public interface ITaskService
{
    List<TaskDto> GetUserTasks(int userId);
    TaskDto CreateTask(int userId, TaskDto taskDto);
    TaskDto UpdateTask(int userId, TaskDto taskDto); 
    void DeleteTask(int userId, int taskId);
}