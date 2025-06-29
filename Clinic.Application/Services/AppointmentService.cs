using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;

namespace Clinic.Application.Services;

public class AppointmentService
{
    private readonly IUnitOfWork _uow;
    public AppointmentService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<Appointment>> ListAsync()
    {
        return await _uow.Repository<Appointment>().ListAsync();
    }

    public async Task<Appointment?> GetAsync(int id)
    {
        return await _uow.Repository<Appointment>().GetByIdAsync(id);
    }

    public async Task CreateAsync(Appointment appointment)
    {
        if (appointment.Patient != null && appointment.Patient.Id == 0)
        {
            await _uow.Repository<Patient>().AddAsync(appointment.Patient);
            await _uow.SaveChangesAsync();
            appointment.PatientId = appointment.Patient.Id;
        }

        await _uow.Repository<Appointment>().AddAsync(appointment);
        await _uow.SaveChangesAsync();
    }
}
