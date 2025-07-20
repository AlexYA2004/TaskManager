using Microsoft.EntityFrameworkCore;
using TaskManager.DAL.Entities;
using TaskManager.DAL.Repositories.Interfaces;

namespace TaskManager.DAL.Repositories.Implementations;

public class UserRepository : IBaseRepository<UserEntity>
{
    private readonly ApplicationDbContext _dbContext;
    
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<UserEntity?> GetAsync(Guid id) => await _dbContext.Users.FindAsync(id);
    
    public async Task AddAsync(UserEntity entity) => await _dbContext.Users.AddAsync(entity);
    
    public void Update(UserEntity entity) => _dbContext.Users.Update(entity);

    public void Delete(UserEntity entity)  => _dbContext.Users.Remove(entity);
    
    public async Task<bool> ExistsAsync(Guid id) => await _dbContext.Users.AnyAsync(x => x.Id == id); 
}