using TaskManagerDemo.Application;

namespace TaskManagerDemo.Core
{
    public class CreateTask
    {
        private readonly ITaskRepository _repository;

        public CreateTask(ITaskRepository repository)
        {
            _repository = repository;
        }

        public TaskEntity Execute(string title)
        {
            var task = new TaskEntity { Title = title };
            _repository.Add(task);
            return task;
        }
    }
}