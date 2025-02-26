using AutoMapper;
using TaskMangmentSystem.DTOs;
using TaskMangmentSystem.Models;

namespace TaskManagementSystem;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<TaskMangmentSystem.Models.Task, TaskDto>().ReverseMap();
    }
}