namespace Bookings.API.Models;

public class Booking
{
    public Booking(Guid venueId, DateTime reservationDate)
    {
        VenueId = venueId;
        ReservationDate = reservationDate;
    }
    
    public Guid Id { get; init; }
    
    public Guid VenueId { get; set; }
    
    public DateTime ReservationDate { get; set; }
    
    public Guid ReservationId { get; set; }
}