using Clinic.SharedKernel;

namespace Clinic.Domain.Entities;

public class Doctor : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int SpecialtyId { get; set; }
    public Specialty? Specialty { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
