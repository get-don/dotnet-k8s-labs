using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoServer.Validations;

namespace TodoServer.DTOs;

public class CreateTodoItemDto
{
    [Required]
    [NotWhiteSpace]
    [MaxLength(100)]    
    public string Content { get; set; } = "";

    [DefaultValue(false)]
    public bool Done { get; set; } = false;
}
