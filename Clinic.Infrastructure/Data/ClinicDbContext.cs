using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Data;

public class ClinicDbContext : DbContext
{
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Specialty> Specialties => Set<Specialty>();
    public DbSet<Appointment> Appointments => Set<Appointment>();

    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
