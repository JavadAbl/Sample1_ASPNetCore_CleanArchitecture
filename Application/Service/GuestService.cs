using Application.Interfaces;
using AutoMapper;
using Domain.Dto;
using Domain.Repository;

namespace Application.Service;

internal class GuestService(IGuestRepository rep, IMapper mapper) : IGuestService
{
    public Task<int> Add(CreateGuestDto guestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<GuestDto?> GetById(int id)
    {
        var guest = await rep.GetByIdAsync(id);
        var guestDto = mapper.Map<GuestDto>(guest);

        return guestDto;
    }
}

