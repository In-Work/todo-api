// Services/TodoService.cs
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Services;

public class TodoService : ITodoService
{
    private readonly TodoDbContext _context;

    public TodoService(TodoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TodoItem>> GetAllAsync()
    {
        return await _context.TodoItems.AsNoTracking().ToListAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(int id)
    {
        return await _context.TodoItems.FindAsync(id);
    }

    public async Task<TodoItem> CreateAsync(TodoItem todo)
    {
        _context.TodoItems.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<bool> UpdateAsync(TodoItem todo)
    {
        var existingTodo = await _context.TodoItems.FindAsync(todo.Id);
        if (existingTodo == null)
        {
            return false;
        }

        existingTodo.Title = todo.Title;
        existingTodo.IsComplete = todo.IsComplete;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var todo = await _context.TodoItems.FindAsync(id);
        if (todo == null) return false;

        _context.TodoItems.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }
}