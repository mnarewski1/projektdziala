using Clinic.Domain.Interfaces;
using Clinic.Infrastructure.Data;
using Clinic.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ClinicDbContext>(options =>
            options.UseSqlite(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
