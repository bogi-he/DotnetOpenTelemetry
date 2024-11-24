using Reservations.API.Models;
using Reservations.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Reservations.API.Services;

public class VenueActivityService(ReservationDbContext context) : IVenueActivityService
{
    private readonly ReservationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    
    public async Task<VenueActivity[]> GetVenueActivitiesByVenueIdAsync(Guid venueId)
    {
        return await _context.VenueActivities
            .Where(a => a.VenueId == venueId)
            .ToArrayAsync();
    }
}