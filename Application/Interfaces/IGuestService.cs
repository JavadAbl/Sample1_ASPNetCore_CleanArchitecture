using Domain.Dto;

namespace Application.Interfaces;

public interface IGuestService
{
    Task<int> Add(CreateGuestDto guestDto);
    Task<GuestDto?> GetById(int id);
}

