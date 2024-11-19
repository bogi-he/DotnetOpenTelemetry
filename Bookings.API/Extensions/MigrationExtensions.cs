using Bookings.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bookings.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

        using var context = serviceScope.ServiceProvider.GetRequiredService<BookingDbContext>();
        
        context.Database.Migrate();
    }
}