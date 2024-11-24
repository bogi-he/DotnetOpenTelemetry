using Reservations.API.Exceptions;
using Reservations.API.Infrastructure.Persistence;
using Reservations.API.Models;

namespace Reservations.API.Services;

public class ReservationService(ReservationDbContext context) : IReservationService
{
    private readonly ReservationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    
    public async Task<Reservation> CreateReservationFromBookingAsync(Guid bookingId, Guid venueActivityId)
    {
        if (bookingId == Guid.Empty)
        {
            throw new ArgumentException("BookingId cannot empty.");
        }

        var venueActivity = await _context.VenueActivities
            .FindAsync(venueActivityId) ?? throw new EntityNotFoundException($"{nameof(VenueActivity)} with key {venueActivityId} was not found.");

        var reservation = new Reservation
        {
            BookingId = bookingId,
            VenueActivityId = venueActivity.Id
        };

        _context.Reservations.Add(reservation);

        await _context.SaveChangesAsync();
        
        return reservation;
    }
}