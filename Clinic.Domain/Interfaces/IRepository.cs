using Clinic.SharedKernel;

namespace Clinic.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> ListAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
