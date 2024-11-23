namespace Reservations.API.Models;

public class VenueActivity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public DateTime ActivityDate { get; set; }
    
    public Guid VenueId { get; set; }

    public Venue Venue { get; set; } = null!;

    public IList<Reservation> Reservations { get; set; } = [];
}