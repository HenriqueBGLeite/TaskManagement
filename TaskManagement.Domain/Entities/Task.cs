using TaskManagement.Communication.Enums;

namespace TaskManagement.Domain.Entities;

public class Task
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PriorityType Priority { get; set; }
    public DateTime DueDate { get; set; }
    public Communication.Enums.TaskStatus Status { get; set; }
}
