using System.Reflection;
using Bookings.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookings.API.Infrastructure.Persistence;
/// <summary>
/// Database context
/// </summary>
/// <remarks>Add Migration: While in BookingsAPI folder - dotnet ef migrations --context BookingDbContext "{message}"</remarks>
public class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options, IConfiguration configuration) : base(options)
    {
    }
    
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}