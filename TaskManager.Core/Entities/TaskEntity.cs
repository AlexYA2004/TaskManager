using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Core.Enums;
using TaskManager.Core.Exceptions.TaskExceptions;

namespace TaskManager.Core.Entities;

public class TaskEntity : BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Title is required")]
    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    [Required]
    [MaxLength(20)]
    public Status Status { get; set; } = Status.New;

    [Required]
    [MaxLength(10)]
    public Priority Priority { get; set; } = Priority.Low;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey("Author")]
    public Guid AuthorId { get; set; }

    public UserEntity Author { get; set; }
    
    public void MarkAsDone() => ChangeStatus(Status.Done);
    public void StartProgress() => ChangeStatus(Status.InProgress);
    public void Cancel() => ChangeStatus(Status.Cancelled);
    public void Reopen() => ChangeStatus(Status.New);
    private void ChangeStatus(Status newStatus)
    {
        ValidateStatusChange(newStatus);
        
        Status = newStatus;
        UpdatedAt = DateTime.UtcNow;
    }
    private void ValidateStatusChange(Status newStatus)
    {
        if (Status == Status.Cancelled && newStatus != Status.Cancelled)
            throw new ChangeTaskStatusException("Cannot change status of cancelled task");
        
        if (Status == Status.Done && newStatus != Status.Done)
            throw new ChangeTaskStatusException("Cannot change status of completed task");
        
        if (Status == Status.Done && newStatus == Status.Cancelled)
            throw new ChangeTaskStatusException("Cannot cancel completed task");
    }

}