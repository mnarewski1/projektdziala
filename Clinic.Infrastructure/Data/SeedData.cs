using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Data;

public static class SeedData
{
    public static void Initialize(ClinicDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Specialties.Any())
        {
            var names = new[] { "Laryngolog", "Stomatolog", "Internista", "Chirurg", "Dietetyk", "Neurolog" };
            foreach (var name in names)
            {
                context.Specialties.Add(new Specialty { Name = name });
            }
            context.SaveChanges();

            int i = 1;
            foreach (var spec in context.Specialties)
            {
                context.Doctors.Add(new Doctor { FirstName = "Doktor", LastName = spec.Name, SpecialtyId = spec.Id });
                i++;
            }
            context.SaveChanges();
        }
    }
}
