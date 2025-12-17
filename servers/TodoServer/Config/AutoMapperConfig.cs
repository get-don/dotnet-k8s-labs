using AutoMapper;
using TodoServer.DTOs;
using TodoServer.Entities;

namespace TodoServer.Config;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<TodoItem, TodoItemDto>().ReverseMap();
        CreateMap<CreateTodoItemDto, TodoItem>();
    }
}
