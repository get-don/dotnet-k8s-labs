using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoServer.DTOs;
using TodoServer.Models;

namespace TodoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private static readonly List<TodoItem> _todoItems = [
            new()
            {
                TodoId = 0,
                Content = "Todo 테스트 버전 만들기.",
                Done = false,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now
            }];

        public TodosController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<TodoItemDto>> GetAll()
        {
            var todoItemDtos = _mapper.Map<List<TodoItemDto>>(_todoItems);
            return Ok(todoItemDtos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(CreateTodoItemDto createTodoItemDto)
        {
            var todoItem = _mapper.Map<TodoItem>(createTodoItemDto);
            todoItem.TodoId = _todoItems.Count;
            todoItem.UpdatedAt = DateTime.UtcNow;
            todoItem.CreatedAt = DateTime.UtcNow;

            _todoItems.Add(todoItem);

            var todoItemDto = _mapper.Map<TodoItemDto>(todoItem);

            return Ok(todoItemDto);
        }

        [HttpPut("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update(long id, bool done = true)
        {
            if (id < 0 || id >= _todoItems.Count)
                return NotFound();

            var item = _todoItems[(int)id];
            item.Done = done;
            item.UpdatedAt = DateTime.UtcNow;            

            return Ok(item);
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(long id)
        {
            if (id < 0 || id >= _todoItems.Count)
                return NotFound();

            _todoItems.RemoveAt((int)id);
            return NoContent();
        }
    }
}
