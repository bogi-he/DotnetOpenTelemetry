using Bookings.API.Infrastructure.Persistence;
using Bookings.API.Models;

namespace Bookings.API.Services;

public class BookingService : IBookingService
{
    private readonly BookingDbContext _context;

    public BookingService(BookingDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Booking> CreateBooking(Guid venueId, DateTime reservationDate)
    {
        // Check Reservation is available
        var booking = new Booking(venueId, reservationDate);
        
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return booking;
    }
}