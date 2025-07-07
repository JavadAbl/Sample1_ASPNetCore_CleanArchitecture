
using Domain.Entity;

namespace Domain.Repository;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(int id);
    Task<Room?> GetByNumberAsync(int number);
    Task<IEnumerable<Room>> GetAllAsync();
    Task<int> AddAsync(Room room);
    Task<bool> UpdateAsync(Room room);
    Task<bool> DeleteAsync(int id);
    Task<int> SaveChnagesAsync();
}
