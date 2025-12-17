using AutoMapper;
using TodoServer.DTOs;
using TodoServer.Models;

namespace TodoServer.Config;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<TodoItem, TodoItemDto>().ReverseMap();
        CreateMap<CreateTodoItemDto, TodoItem>();
    }
}
