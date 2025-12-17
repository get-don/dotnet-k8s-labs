using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoServer.DTOs;
using TodoServer.Entities;
using TodoServer.Repository.IRepository;

namespace TodoServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly ITodosRepository _repository;
    private readonly IMapper _mapper;
   

    public TodosController(ITodosRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;            
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [EndpointSummary("모든 할 일 목록을 조회한다.")]
    public async Task<ActionResult<List<TodoItemDto>>> GetAll()
    {
        var todoItems = await _repository.GetAllAsync();
        var todoItemDtos = _mapper.Map<List<TodoItemDto>>(todoItems);
        return Ok(todoItemDtos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("새로운 할 일을 작성한다.")]
    public async Task<ActionResult> Create(CreateTodoItemDto createTodoItemDto)
    {
        var todoItem = _mapper.Map<TodoItem>(createTodoItemDto);

        var todoID = await _repository.CreateAsync(todoItem);
        todoItem.TodoId = todoID;

        var todoItemDto = _mapper.Map<TodoItemDto>(todoItem);

        return Ok(todoItemDto);
    }

    [HttpPut("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("특정 ID에 해당하는 할 일의 완료 유무를 수정한다.")]
    public async Task<ActionResult> Update(long id, bool done = true)
    {
        var todoItem = await _repository.GetByIdAsync(id);
        if (todoItem == null)
            return NotFound();

        todoItem.Done = done;

        await _repository.UpdateAsync(todoItem);            

        return Ok(todoItem);
    }

    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("특정 ID에 해당하는 할 일을 삭제한다.")]
    public async Task<ActionResult> Delete(long id)
    {
        var exists = await _repository.Exists(id);
        if (!exists)
            return NotFound();

        await _repository.RemoveAsync(id);

        return NoContent();
    }

    [HttpGet("exception")]
    [EndpointSummary("전역 예외 처리 테스트")]
    public void ExceptionTest() => throw new Exception("전역 예외 처리 테스트입니다.");
}
