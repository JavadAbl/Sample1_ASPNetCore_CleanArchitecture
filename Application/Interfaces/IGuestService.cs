using Domain.Dto;
using Domain.Entity;

namespace Application.Interfaces;

public interface IGuestService
{
    Task<int> Add(CreateGuestDto guestDto);
    Task<Guest?> GetById(int id);
}

