using System.Net;
using Application.Interfaces;
using AutoMapper;
using Domain.Dto;
using Domain.Repository;
using MediatR;

namespace Application.Domain.Rooms.Query;

public class GetRoomByNumberQueryHandler(IRoomRepository rep, IMapper mapper) : IRequestHandler<GetRoomByNumberQuery, Result<RoomDto?>>
{
    public async Task<Result<RoomDto?>> Handle(GetRoomByNumberQuery request, CancellationToken cancellationToken)
    {
        var room = await rep.GetByNumberAsync(request.Number);

        if (room is null)
            return Result<RoomDto?>.Fail($"Room with number {request.Number} not found.", (int)HttpStatusCode.NotFound);

        var roomDto = mapper.Map<RoomDto>(room);

        return Result<RoomDto?>.Ok(roomDto);
    }
}

