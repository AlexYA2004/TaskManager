using System.ComponentModel.DataAnnotations;

namespace TaskManager.DAL.Entities;

public class UserEntity : BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Username is required")]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; } 

    [Required]
    [MaxLength(20)]
    public Role Role { get; set; } = Role.User;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<TaskEntity> UserTasks { get; set; } = new List<TaskEntity>();
}

public enum Role
{
    User,
    Admin
}