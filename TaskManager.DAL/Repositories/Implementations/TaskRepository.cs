using Microsoft.EntityFrameworkCore;
using TaskManager.DAL.Entities;
using TaskManager.DAL.Repositories.Interfaces;

namespace TaskManager.DAL.Repositories.Implementations;

public class TaskRepository : IBaseRepository<TaskEntity>
{
    private readonly ApplicationDbContext _dbContext;

    public TaskRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TaskEntity?> GetAsync(Guid id) => await _dbContext.Tasks.FindAsync(id);

    public async Task AddAsync(TaskEntity entity) => await _dbContext.Tasks.AddAsync(entity);

    public void Update(TaskEntity entity) => _dbContext.Tasks.Update(entity);

    public void Delete(TaskEntity entity)  => _dbContext.Tasks.Remove(entity);

    public async Task<bool> ExistsAsync(Guid id) => await _dbContext.Tasks.AnyAsync(x => x.Id == id);
}
   