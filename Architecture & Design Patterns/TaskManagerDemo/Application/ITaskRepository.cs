using TaskManagerDemo.Core;

namespace TaskManagerDemo.Application
{
    public interface ITaskRepository
    {
        void Add(TaskEntity task);
        List<TaskEntity> GetAll();
    }
}