using Bookings.API.Models;

namespace Bookings.API.Services;

public interface IBookingService
{
    Task<Booking> CreateBooking(Guid venueActivityId);
}