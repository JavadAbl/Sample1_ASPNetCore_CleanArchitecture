using Application.Interfaces;
using Domain.Dto.Room;
using Domain.Enum;
using MediatR;

namespace Application.Domain.Rooms.Command;

public class CreateRoomCommand(CreateRoomDto dto) : IRequest<Result<int>>
{
    public CreateRoomDto Dto { get; } = dto;
}

