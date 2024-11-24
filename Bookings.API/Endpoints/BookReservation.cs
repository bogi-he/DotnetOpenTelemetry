using Common.Interfaces;
using Bookings.API.Services;

namespace Bookings.API.Endpoints;

public class BookReservation : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("bookings/activity/{venueActivityId}", async (Guid venueActivityId, IBookingService bookingService) =>
        {
            await bookingService.CreateBooking(venueActivityId);
            
            return Results.Ok();
        });
    }
}