using Domain.Dto.Guest;
using Domain.Entity;

namespace Application.Profile;

internal class RoomProfile : AutoMapper.Profile
{
    public RoomProfile()
    {
        CreateMap<Room, GuestDto>();
    }
}

