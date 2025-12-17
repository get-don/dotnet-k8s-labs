using TodoServer.Entities;

namespace TodoServer.Repository.IRepository;

public interface ITodosRepository
{
    Task<bool> Exists(long todoId);
    Task<List<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(long todoId);
    Task<long> CreateAsync(TodoItem todoItem);    
    Task UpdateAsync(TodoItem todoItem);
    Task RemoveAsync(long todoId);    
}
