using Reservations.API.Models;

namespace Reservations.API.Services;

public interface IVenueActivityService
{
    public Task<VenueActivity[]> GetVenueActivitiesByVenueIdAsync(Guid venueId);
}