using TaskManager.Core.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.DAL.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetAsync(Guid id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> ExistsAsync(Guid id);
}