using Microsoft.EntityFrameworkCore;
using Reservations.API.Infrastructure.Persistence;
using Reservations.API.Models;

namespace Reservations.API.Services;

public class VenueService(ReservationDbContext context) : IVenueService
{
    private readonly ReservationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<Venue[]> GetVenuesAsync()
    {
        return await _context.Venues.ToArrayAsync();
    }
}