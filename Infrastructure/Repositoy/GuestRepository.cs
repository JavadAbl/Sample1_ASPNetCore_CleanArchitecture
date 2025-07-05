using Domain.Entity;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositoy;

internal class GuestRepository(AppDbContext appDb) : IGuestRepository
{
    public async Task<int> AddAsync(Guest guest)
    {
        if (guest == null)
            throw new ArgumentNullException(nameof(guest));
        guest.CreatedAt = DateTime.UtcNow;
        guest.UpdatedAt = DateTime.UtcNow;
        appDb.Guests.Add(guest);
        await appDb.SaveChangesAsync();

        return guest.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var rowsAffected = await appDb.Guests
        .Where(g => g.Id == id)
        .ExecuteDeleteAsync();

        return rowsAffected > 0;
    }

    public async Task<IEnumerable<Guest>> GetAllAsync()
    {
        return await appDb.Guests.Include(g => g.Address)
              .Include(g => g.Room)
              .ToListAsync();
    }

    public async Task<Guest?> GetByIdAsync(int id)
    {
        return await appDb.Guests.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Guest?> GetByPassNumberAsync(string passNumber)
    {
        return await appDb.Guests.FirstOrDefaultAsync(g => g.PassNumber == passNumber);
    }

    public async Task UpdateAsync(Guest guest)
    {
        appDb.Guests.Attach(guest);
        // appDb.Entry(guest).State = EntityState.Modified;
        appDb.Entry(guest).CurrentValues.SetValues(guest);
        await appDb.SaveChangesAsync();
    }
}
