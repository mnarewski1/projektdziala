namespace Clinic.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : Clinic.SharedKernel.BaseEntity;
    Task<int> SaveChangesAsync();
}
