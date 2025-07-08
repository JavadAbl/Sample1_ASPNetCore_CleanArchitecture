using Domain.Entity;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositoy;

internal class RoomRepository(AppDbContext appDb) : IRoomRepository
{
    //----------------------------------------------------------
    public async Task<int> AddAsync(Room room)
    {
        await appDb.Rooms.AddAsync(room);
        await appDb.SaveChangesAsync();
        return room.Id;
    }

    //----------------------------------------------------------
    public async Task<bool> DeleteAsync(int id)
    {
        var rowsAffected = await appDb.Rooms
      .Where(r => r.Id == id)
      .ExecuteDeleteAsync();

        return rowsAffected > 0;
    }

    //----------------------------------------------------------
    public async Task<IEnumerable<Room>> GetAllAsync()
    {
        return await appDb.Rooms.Include(r => r.Guest).ToListAsync();
    }

    //----------------------------------------------------------
    public async Task<Room?> GetByIdAsync(int id)
    {
        return await appDb.Rooms.FirstOrDefaultAsync(r => r.Id == id);
    }

    //----------------------------------------------------------
    public async Task<Room?> GetByNumberAsync(int number)
    {
        return await appDb.Rooms.FirstOrDefaultAsync(g => g.Number == number);
    }

    //----------------------------------------------------------
    public async Task<int> SaveChnagesAsync() => await appDb.SaveChangesAsync();

    //----------------------------------------------------------
    public Task<bool> UpdateAsync(Room room)
    {
        throw new NotImplementedException();
    }
}
