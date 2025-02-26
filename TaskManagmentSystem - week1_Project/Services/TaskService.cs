using AutoMapper;
using TaskMangmentSystem.DTOs;
using TaskMangmentSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepo;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepo, IMapper mapper)
    {
        _taskRepo = taskRepo;
        _mapper = mapper;
    }

    public List<TaskDto> GetUserTasks(int userId)
    {
        var tasks = _taskRepo.GetByUserId(userId);
        return _mapper.Map<List<TaskDto>>(tasks);
    }

    public TaskDto CreateTask(int userId, TaskDto taskDto)
    {
        var task = _mapper.Map<TaskMangmentSystem.Models.Task>(taskDto);
        task.UserId = userId;
        _taskRepo.Add(task);
        return _mapper.Map<TaskDto>(task);
    }
}