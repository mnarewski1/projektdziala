using Clinic.Application.Services;
using Clinic.Domain.Entities;
using Clinic.Infrastructure.Extensions;
using Clinic.Infrastructure.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.File("Logs/info-.txt", rollingInterval: RollingInterval.Day)
      .WriteTo.File("Logs/error-.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error);
});

builder.Services.AddInfrastructure("Data Source=clinic.db");
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ClinicDbContext>();
    SeedData.Initialize(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/appointments", async (AppointmentService service) =>
{
    return await service.ListAsync();
});

app.MapGet("/appointments/{id}", async (AppointmentService service, int id) =>
{
    var appt = await service.GetAsync(id);
    return appt is not null ? Results.Ok(appt) : Results.NotFound();
});

app.MapPost("/appointments", async (AppointmentService service, Appointment appointment) =>
{
    await service.CreateAsync(appointment);
    return Results.Created($"/appointments/{appointment.Id}", appointment);
});

app.Run();
