using TaskManagerDemo.Core;
using TaskManagerDemo.Application;

namespace TaskManagerDemo.Infrastructure
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskEntity> _tasks = new List<TaskEntity>();
        private int _idCounter = 1;

        public void Add(TaskEntity task)
        {
            task.Id = _idCounter++;
            _tasks.Add(task);
        }

        public List<TaskEntity> GetAll()
        {
            return _tasks;
        }
    }
}