using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [ForeignKey("Author")]
    public Guid AuthorId { get; set; }

    public UserEntity Author { get; set; }
}

public enum Status
{
    New,
    InProgress,
    Done
}

public enum Priority
{
    Low,
    Medium,
    High
}