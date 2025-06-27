using Domain.Dto;

namespace Application.Interfaces;

public interface IGuestService
{
    Task<int> Add(CreateGuestDto guestDto);
    Task<IEnumerable<GuestDto>> GetAll();
    Task<GuestDto?> GetById(int id);
    Task<GuestDto?> GetByPassNumber(string passNumber);
}

