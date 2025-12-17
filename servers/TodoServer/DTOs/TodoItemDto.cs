namespace TodoServer.DTOs;

public class TodoItemDto
{
    public long TodoId { get; set; }
    public string Content { get; set; } = "";
    public bool Done { get; set; } = false;
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
