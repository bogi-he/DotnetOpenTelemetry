using Reservations.API.Models;
using Reservations.API.Services;
using Common.Interfaces;

namespace Reservations.API.Endpoints;

public class GetVenues : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("venues", async (IVenueService venueService) =>
        {
            var venues = await venueService.GetVenuesAsync();

            return TypedResults.Ok(venues.Select(VenueResponse.FromVenue));
        });
    }
}

public record VenueResponse(Guid Id, string Name)
{
    public static VenueResponse FromVenue(Venue venue)
    {
        return new VenueResponse(venue.Id, venue.Name);
    }
}