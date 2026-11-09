using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Services;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    // GET: api/todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
    {
        var todos = await _todoService.GetAllAsync();
        return Ok(todos);
    }

    // GET: api/todo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetTodo(int id)
    {
        var todo = await _todoService.GetByIdAsync(id);
        if (todo == null) return NotFound();
        return todo;
    }

    // POST: api/todo
    [HttpPost]
    public async Task<ActionResult<TodoItem>> PostTodo(TodoItem todo)
    {
        var created = await _todoService.CreateAsync(todo);
        return CreatedAtAction(nameof(GetTodo), new { id = created.Id }, created);
    }

    // PUT: api/todo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodo(int id, TodoItem todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }

        var updated = await _todoService.UpdateAsync(todo);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/todo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var deleted = await _todoService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}