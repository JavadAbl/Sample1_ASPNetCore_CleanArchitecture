using Application.Interfaces;
using Domain.Dto.Guest;
using Domain.Dto.Room;
using MediatR;

namespace Application.Domain.Rooms.Command;

public class AddGuestToRoomCommand(AddGuestToRoomDto dto) : IRequest<Result>
{
    public int RoomId { get; } = dto.RoomId!.Value;
    public int GuestId { get; } = dto.GuestId!.Value;
}

