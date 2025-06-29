using Clinic.SharedKernel;

namespace Clinic.Domain.Entities;

public class Appointment : BaseEntity
{
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
    public DateTime AppointmentTime { get; set; }
}
