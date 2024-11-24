using Reservations.API.Models;
using Reservations.API.Services;
using Common.Interfaces;

namespace Reservations.API.Endpoints;

public class GetVenueActivities : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("venues/{venueId}/activities", async (Guid venueId, IVenueActivityService venueActivityService) =>
        {
            var venueActivities = await venueActivityService.GetVenueActivitiesByVenueIdAsync(venueId);
            
            return TypedResults.Ok(venueActivities.Select(VenueActivityResponse.FromVenueActivity));
        });
    }
}

public record VenueActivityResponse(Guid Id, string Name, DateTime Date)
{
    public static VenueActivityResponse FromVenueActivity(VenueActivity venueActivity)
    {
        return new VenueActivityResponse(venueActivity.Id, venueActivity.Name, venueActivity.ActivityDate);
    }
}