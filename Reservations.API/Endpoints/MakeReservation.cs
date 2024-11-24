using Common.Interfaces;
using Reservations.API.Services;

namespace Reservations.API.Endpoints;

public class MakeReservation : IEndpoint
{
    private record MakeReservationRequest(Guid VenueActivityId, Guid BookingId);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("reservations", async (MakeReservationRequest request, IReservationService reservationService) =>
        {
            var reservation = await reservationService
                .CreateReservationFromBookingAsync(request.BookingId, request.VenueActivityId);

            return Results.Ok(reservation.Id);
        });
    }
}