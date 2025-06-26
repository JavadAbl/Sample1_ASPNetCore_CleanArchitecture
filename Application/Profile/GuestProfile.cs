using Domain.Dto;
using Domain.Entity;

namespace Application.Profile;

internal class GuestProfile : AutoMapper.Profile
{
    public GuestProfile()
    {
        CreateMap<Guest, GuestDto>();
        CreateMap<CreateGuestDto, Guest>();

    }
}

