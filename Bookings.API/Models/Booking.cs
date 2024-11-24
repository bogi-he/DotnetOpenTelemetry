using Bookings.API.Enums;

namespace Bookings.API.Models;

public class Booking
{
    public Booking(Guid venueActivityId)
    {
        VenueActivityId = venueActivityId;
    }
    
    public Guid Id { get; init; }
    
    public Guid VenueActivityId { get; set; }
    
    public Guid? ReservationId { get; set; }
    
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
}