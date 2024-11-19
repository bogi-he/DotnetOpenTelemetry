using Bookings.API.Services;
using Common.Extensions;
using Asp.Versioning;
using Bookings.API.Extensions;
using Bookings.API.Infrastructure.Persistence;
using Bookings.API.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddApiServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

var apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1))
    .ReportApiVersions()
    .Build();

var versionedGroup = app
    .MapGroup("api/v{version:apiVersion}")
    .WithApiVersionSet(apiVersionSet);

app.MapEndpoints(versionedGroup);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();