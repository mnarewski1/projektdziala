using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;

namespace Clinic.Application.Services;

public class DoctorService
{
    private readonly IUnitOfWork _uow;
    public DoctorService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<Doctor>> ListAsync()
    {
        return await _uow.Repository<Doctor>().ListAsync();
    }
}
