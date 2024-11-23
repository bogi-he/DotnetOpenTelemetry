using System.Reflection;
using Reservations.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Reservations.API.Infrastructure.Persistence;

public class ReservationDbContext : DbContext
{
    public ReservationDbContext(DbContextOptions<ReservationDbContext> options, IConfiguration configuration) : base(options)
    {
    }
    
    public DbSet<Reservation> Reservations => Set<Reservation>();

    public DbSet<Venue> Venues => Set<Venue>();
    
    public DbSet<VenueActivity> VenueActivities => Set<VenueActivity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}