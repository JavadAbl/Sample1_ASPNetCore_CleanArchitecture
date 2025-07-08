using Application.Interfaces;
using Domain.Dto;
using MediatR;

namespace Application.Domain.Rooms.Query;

public class GetRoomByIdQuery(int id) : IRequest<Result<RoomDto?>>
{
    public int Id { get; } = id;
}

