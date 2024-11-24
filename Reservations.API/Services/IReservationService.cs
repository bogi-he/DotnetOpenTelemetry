using Reservations.API.Models;

namespace Reservations.API.Services;

public interface IReservationService
{
    public Task<Reservation> CreateReservationFromBookingAsync(Guid bookingId, Guid venueActivityId );
}