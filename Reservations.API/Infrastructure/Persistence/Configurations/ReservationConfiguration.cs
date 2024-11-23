using Reservations.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reservations.API.Infrastructure.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder
            .HasKey(b => b.Id);
        
        builder
            .HasOne(r => r.VenueActivity)
            .WithMany(a => a.Reservations)
            .HasForeignKey(r => r.VenueActivityId);
    }
}