using Reservations.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reservations.API.Infrastructure.Persistence.Configurations;

public class VenueActivityConfiguration : IEntityTypeConfiguration<VenueActivity>
{
    public void Configure(EntityTypeBuilder<VenueActivity> builder)
    {
        builder
            .HasKey(b => b.Id);
        
        builder
            .Property(v => v.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}