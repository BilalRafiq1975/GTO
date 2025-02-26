using TaskMangmentSystem.Models;
using TaskMangmentSystem.Data;


namespace TaskManagementSystem.Repositories;
public interface ITaskRepository
{
    List<TaskMangmentSystem.Models.Task> GetByUserId(int userId);
    void Add(TaskMangmentSystem.Models.Task task);
    void Update(TaskMangmentSystem.Models.Task task);
    void Delete(int taskId);
}