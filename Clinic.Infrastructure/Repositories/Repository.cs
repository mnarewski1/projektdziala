using Clinic.Domain.Interfaces;
using Clinic.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Clinic.Infrastructure.Data;

namespace Clinic.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ClinicDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ClinicDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> ListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
