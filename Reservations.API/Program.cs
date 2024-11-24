using Reservations.API.Extensions;
using Reservations.API.Setup;
using Reservations.API.Services;
using Common.Extensions;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddScoped<IVenueActivityService, VenueActivityService>();

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
    await app.ApplyMigrationsAndSeedDataAsync();
}

app.UseHttpsRedirection();

app.Run();