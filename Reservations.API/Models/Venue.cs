namespace Reservations.API.Models;

public class Venue
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Capacity { get; set; } = 1;

    public IList<VenueActivity> VenueActivities { get; set; } = [];
}