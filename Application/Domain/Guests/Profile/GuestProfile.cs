using Application.Domain.Guests.Command;
using Domain.Dto.Guest;
using Domain.Entity;

namespace Application.Domain.Guests.Profile;

internal class GuestProfile : AutoMapper.Profile
{
    public GuestProfile()
    {
        CreateMap<Guest, GuestDto>();
        CreateMap<CreateGuestDto, CreateGuestCommand>();
        CreateMap<CreateGuestCommand, Guest>();

        CreateMap<UpdateGuestDto, UpdateGuestCommand>();
        CreateMap<UpdateGuestCommand, Guest>();

    }
}

