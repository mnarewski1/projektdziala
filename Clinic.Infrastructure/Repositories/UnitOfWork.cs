using Clinic.Domain.Interfaces;
using Clinic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClinicDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(ClinicDbContext context)
    {
        _context = context;
    }

    public IRepository<T> Repository<T>() where T : Clinic.SharedKernel.BaseEntity
    {
        if (_repositories.TryGetValue(typeof(T), out var repo))
        {
            return (IRepository<T>)repo;
        }

        var repositoryType = typeof(Repository<>).MakeGenericType(typeof(T));
        var instance = Activator.CreateInstance(repositoryType, _context)!;
        _repositories.Add(typeof(T), instance);
        return (IRepository<T>)instance;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
