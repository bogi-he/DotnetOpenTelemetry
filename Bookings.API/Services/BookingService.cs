using Bookings.API.Infrastructure.Persistence;
using Bookings.API.Models;

namespace Bookings.API.Services;

public class BookingService(BookingDbContext context) : IBookingService
{
    private readonly BookingDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<Booking> CreateBooking(Guid venueActivityId)
    {
        var booking = new Booking(venueActivityId);
        
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return booking;
    }
}