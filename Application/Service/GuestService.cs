using Application.Interfaces;
using Domain.Dto;
using Domain.Entity;
using Domain.Repository;

namespace Application.Service;

internal class GuestService(IGuestRepository rep) : IGuestService
{
    public Task<int> Add(CreateGuestDto guestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Guest?> GetById(int id)
    {
        return await rep.GetByIdAsync(id);
    }
}

