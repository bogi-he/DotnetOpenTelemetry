using Reservations.API.Infrastructure.Persistence;

namespace Reservations.API.Extensions;

public static class InitializerExtensions
{
    public static async Task ApplyMigrationsAndSeedDataAsync(this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

        var dbContextInitializer = serviceScope.ServiceProvider.GetRequiredService<ReservationDbContextInitializer>();

        await dbContextInitializer.ApplyMigrationsAsync();
        
        await dbContextInitializer.SeedAsync();
    }
}