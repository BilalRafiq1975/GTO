using TaskManagerDemo.Application;

namespace TaskManagerDemo.Core
{
    public class ListTasks
    {
        private readonly ITaskRepository _repository;

        public ListTasks(ITaskRepository repository)
        {
            _repository = repository;
        }

        public List<TaskEntity> Execute()
        {
            return _repository.GetAll();
        }
    }
}