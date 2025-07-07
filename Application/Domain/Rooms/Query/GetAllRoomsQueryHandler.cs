using Application.Interfaces;
using AutoMapper;
using Domain.Dto;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Domain.Rooms.Query;

public class GetAllRoomsQueryHandler(IRoomRepository rep, IMapper mapper) : IRequestHandler<GetAllRoomsQuery, Result<IEnumerable<RoomDto>>>
{
    public async Task<Result<IEnumerable<RoomDto>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await rep.GetAllAsync();
        var roomDtos = mapper.Map<IEnumerable<RoomDto>>(rooms);
        return Result<IEnumerable<RoomDto>>.Ok(roomDtos);
    }
}
