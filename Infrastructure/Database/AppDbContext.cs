using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

internal class AppDbContext : DbContext
{
    internal DbSet<Guest> Guests { get; set; }
    internal DbSet<Room> Rooms { get; set; }
}

