// Services/ITodoService.cs
using Web.Models;

namespace Web.Services;

public interface ITodoService
{
    Task<IEnumerable<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(int id);
    Task<TodoItem> CreateAsync(TodoItem todo);
    Task<bool> UpdateAsync(TodoItem todo);
    Task<bool> DeleteAsync(int id);
}