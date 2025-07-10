using Application.Interfaces;
using Domain.Dto.Room;
using MediatR;

namespace Application.Domain.Rooms.Command;

public class UpdateRoomCommand(UpdateRoomDto dto) : IRequest<Result>
{
    public UpdateRoomDto Dto { get; } = dto;
}

