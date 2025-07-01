using Application.Domain.Guests.Command;
using Domain.Dto;
using Domain.Entity;

namespace Application.Domain.Guests.Profile;

internal class GuestProfile : AutoMapper.Profile
{
    public GuestProfile()
    {
        CreateMap<Guest, GuestDto>();
        CreateMap<CreateGuestCommand, Guest>();

    }
}

