using Domain.Entity;

namespace Domain.Repository;

public interface IGuestRepository
{
    Task<Guest?> GetByIdAsync(int id);
    Task<Guest?> GetByPassNumberAsync(string passNumber);
    Task<IEnumerable<Guest>> GetAllAsync();
    Task<int> AddAsync(Guest guest);
    Task<bool> UpdateAsync(Guest guest);
    Task<bool> DeleteAsync(int id);
    Task<int> SaveChnagesAsync();

}

