using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

internal class AppDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    internal DbSet<Guest> Guests { get; set; }
    internal DbSet<Room> Rooms { get; set; }
    internal DbSet<Cleaner> Cleaners { get; set; }
    internal DbSet<RoomCleaners> RoomCleaners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<RoomCleaners>().HasOne(c => c.Room).WithMany<Cleaner>();

    }
}

