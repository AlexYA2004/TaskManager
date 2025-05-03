using Microsoft.EntityFrameworkCore;

namespace TaskManager.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}
    
    
}