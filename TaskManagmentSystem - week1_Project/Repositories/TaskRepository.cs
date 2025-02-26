using TaskMangmentSystem.Models;
using TaskMangmentSystem.Data;
namespace TaskManagementSystem.Repositories;
public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;
    public TaskRepository(AppDbContext context) => _context = context;

    public List<TaskMangmentSystem.Models.Task> GetByUserId(int userId) => _context.Tasks.Where(t => t.UserId == userId).ToList();
    public void Add(TaskMangmentSystem.Models.Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void Update(TaskMangmentSystem.Models.Task task){
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public void Delete(int taskId){
        var task = _context.Tasks.FirstOrDefault(t=> t.Id == taskId);
        if (task !=null){
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}