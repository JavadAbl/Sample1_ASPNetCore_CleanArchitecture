using Domain.Entity;

namespace Domain.Repository;

public interface IGuestRepository
{
    Task<Guest?> GetByIdAsync(int id);
    Task<Guest?> GetByPassNumberAsync(string passNumber);
    Task<IEnumerable<Guest>> GetAllAsync();
    Task<int> AddAsync(Guest guest);
    Task UpdateAsync(Guest guest);
    Task DeleteAsync(int id);

}

