using Application.Interfaces;
using AutoMapper;
using Domain.Dto;
using Domain.Repository;

namespace Application.Service;

internal class GuestService(IGuestRepository rep, IMapper mapper) : IGuestService
{
    public async Task<int> Add(CreateGuestDto guestDto)
    {
        var existingGuest = await rep.GetByPassNumberAsync(guestDto.PassNumber);
        if (existingGuest != null)
        {
            throw new InvalidOperationException($"Guest with pass number {guestDto.PassNumber} already exists.");
        }

        var guest = mapper.Map<Domain.Entity.Guest>(guestDto);
        var id = await rep.AddAsync(guest);
        return id;
    }

    public async Task<IEnumerable<GuestDto>> GetAll()
    {
        var guests = await rep.GetAllAsync();
        var guestDtos = mapper.Map<IEnumerable<GuestDto>>(guests);
        return guestDtos;
    }

    public async Task<GuestDto?> GetById(int id)
    {
        var guest = await rep.GetByIdAsync(id);
        var guestDto = mapper.Map<GuestDto>(guest);

        return guestDto;
    }

    public async Task<GuestDto?> GetByPassNumber(string passNumber)
    {
        var guest = await rep.GetByPassNumberAsync(passNumber);

        var guestDto = mapper.Map<GuestDto>(guest);

        return guestDto;
    }
}

