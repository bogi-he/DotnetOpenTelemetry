namespace Reservations.API.Models;

public class Reservation
{
    public Guid Id { get; set; }
    
    public Guid BookingId { get; set; }
    
    public Guid VenueActivityId { get; set; }

    public VenueActivity VenueActivity { get; set; } = null!;
}