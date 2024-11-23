using Reservations.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reservations.API.Infrastructure.Persistence.Configurations;

public class VenueConfiguration : IEntityTypeConfiguration<Venue>
{
    public void Configure(EntityTypeBuilder<Venue> builder)
    {
        builder
            .HasKey(b => b.Id);
        
        builder
            .Property(v => v.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .HasMany(v => v.VenueActivities)
            .WithOne(v => v.Venue)
            .HasForeignKey(v => v.VenueId);
    }
}