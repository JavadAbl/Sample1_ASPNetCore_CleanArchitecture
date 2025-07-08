using System.Net;
using Application.Interfaces;
using AutoMapper;
using Domain.Dto;
using Domain.Repository;
using MediatR;

namespace Application.Domain.Rooms.Query;

public class GetRoomByIdQueryHandler(IRoomRepository rep, IMapper mapper) : IRequestHandler<GetRoomByIdQuery, Result<RoomDto?>>
{
    public async Task<Result<RoomDto?>> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await rep.GetByIdAsync(request.Id);

        if (room is null)
            return Result<RoomDto?>.Fail($"Room with id {request.Id} not found.", (int)HttpStatusCode.NotFound);

        var roomDto = mapper.Map<RoomDto>(room);

        return Result<RoomDto?>.Ok(roomDto);
    }
}

