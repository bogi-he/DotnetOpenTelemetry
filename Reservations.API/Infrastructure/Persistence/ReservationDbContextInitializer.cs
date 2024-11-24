using Microsoft.EntityFrameworkCore;
using Reservations.API.Models;

namespace Reservations.API.Infrastructure.Persistence;

public class ReservationDbContextInitializer(ReservationDbContext context)
{
    private readonly ReservationDbContext _context = context;

    public async Task ApplyMigrationsAsync()
    {
        await _context.Database.MigrateAsync();
    }

    public async Task SeedAsync()
    {
        if (!_context.Venues.Any())
        {
            var venues = new[]
            {
                new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = "Wembley Stadium",
                    Capacity = 90000,
                    VenueActivities = 
                    [
                        new VenueActivity
                        {
                            ActivityDate = new DateTime(new DateOnly(DateTime.Today.Year, DateTime.Today.Month + 1, 5), new TimeOnly(20, 30)),
                            Name = $"Oasis live {DateTime.Today.Year}"
                        },
                    ]
                },
                new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = "Scala",
                    Capacity = 2,
                    VenueActivities = 
                    [
                        new VenueActivity
                        {
                            ActivityDate = new DateTime(new DateOnly(DateTime.Today.Year, DateTime.Today.Month + 5, 21), new TimeOnly(12, 30)),
                            Name = "Been Stellar",
                            Reservations = 
                            [
                                new Reservation
                                {
                                    BookingId = Guid.NewGuid(),
                                },
                                new Reservation
                                {
                                    BookingId = Guid.NewGuid(),
                                },
                            ]
                        },
                    ]
                }
            };
            
            _context.Venues.AddRange(venues);

            await _context.SaveChangesAsync();
        }
    }
}