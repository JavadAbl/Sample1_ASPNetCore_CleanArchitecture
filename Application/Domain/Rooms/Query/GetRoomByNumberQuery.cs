using Application.Interfaces;
using Domain.Dto;
using MediatR;

namespace Application.Domain.Rooms.Query;

public class GetRoomByNumberQuery(int number) : IRequest<Result<RoomDto?>>
{
    public int Number { get; } = number;
}

