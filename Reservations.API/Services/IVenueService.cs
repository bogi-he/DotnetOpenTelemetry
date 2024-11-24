using Reservations.API.Models;

namespace Reservations.API.Services;

public interface IVenueService
{
    public Task<Venue[]> GetVenuesAsync();
}