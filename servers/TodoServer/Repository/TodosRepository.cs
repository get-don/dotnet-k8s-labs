using TodoServer.Entities;
using TodoServer.Repository.IRepository;

namespace TodoServer.Repository;

public class TodosRepository : ITodosRepository
{
    private static readonly List<TodoItem> _todoItems = [
           new()
            {
                TodoId = 12345,
                Content = "Todo 테스트 버전 만들기.",
                Done = false,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now
            }];


    public async Task<bool> Exists(long todoId)
    {        
        // 아직 DB 연결이 없기 때문에 임시 작성
        await Task.Delay(100);

        return _todoItems.Any(e => e.TodoId == todoId);
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        await Task.Delay(100);
     
        return _todoItems;
    }

    public async Task<TodoItem?> GetByIdAsync(long todoId)
    {
        await Task.Delay(100);

        return _todoItems.FirstOrDefault(e => e.TodoId == todoId);
    }

    public async Task<long> CreateAsync(TodoItem todoItem)
    {
        await Task.Delay(100);

        var rand = new Random();
        todoItem.TodoId = rand.Next();
        todoItem.UpdatedAt = DateTime.UtcNow;
        todoItem.CreatedAt = DateTime.UtcNow;

        _todoItems.Add(todoItem);

        return todoItem.TodoId;
    }

    public async Task UpdateAsync(TodoItem todoItem)
    {
        await Task.Delay(100);

        todoItem.UpdatedAt = DateTime.UtcNow;
    }

    public async Task RemoveAsync(long todoId)
    {
        await Task.Delay(100);

        var index = _todoItems.FindIndex(e => e.TodoId == todoId);
        if(index >= 0)
        {
            _todoItems.RemoveAt(index);
        }
    }

}
