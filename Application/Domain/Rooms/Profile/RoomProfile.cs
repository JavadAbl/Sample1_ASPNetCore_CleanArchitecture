

using Application.Domain.Rooms.Command;
using Domain.Dto;
using Domain.Dto.Room;
using Domain.Entity;

namespace Application.Domain.Rooms.Profile;

internal class RoomProfile : AutoMapper.Profile
{

    public RoomProfile()
    {
        CreateMap<Room, RoomDto>();

        CreateMap<Room, RoomSummaryDto>();

        CreateMap<CreateRoomDto, Room>();

        CreateMap<UpdateRoomDto, Room>();


    }
}
