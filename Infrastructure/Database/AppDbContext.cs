using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

internal class AppDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    internal DbSet<Guest> Guests { get; set; }
    internal DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Room>().HasOne<Guest>(Room => Room.Guest)
            .WithOne(guest => guest.Room).HasForeignKey<Guest>(guest => guest.RoomId);
    }
}

