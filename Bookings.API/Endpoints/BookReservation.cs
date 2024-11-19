using Common.Interfaces;
using Bookings.API.Services;

namespace Bookings.API.Endpoints;

public class BookReservation : IEndpoint
{
    private record BookReservationRequest(Guid VenueId, DateTime ReservationDate);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("bookings", async (BookReservationRequest request, IBookingService bookingService) =>
        {
            await bookingService.CreateBooking(request.VenueId, request.ReservationDate);
            
            return Results.Ok();
        });
    }
}