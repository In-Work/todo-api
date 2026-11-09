using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class TodoItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Заголовок обязателен")]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
}