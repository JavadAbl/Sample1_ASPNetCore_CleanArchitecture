

using Domain.Dto;
using Domain.Entity;

namespace Application.Domain.Rooms.Profile;

internal class RoomProfile : AutoMapper.Profile
{

    public RoomProfile()
    {
        CreateMap<Room, RoomDto>();
        /* CreateMap<CreateGuestDto, CreateGuestCommand>();
        CreateMap<CreateGuestCommand, Guest>();

        CreateMap<UpdateGuestDto, UpdateGuestCommand>();
        CreateMap<UpdateGuestCommand, Guest>(); */

    }

}
