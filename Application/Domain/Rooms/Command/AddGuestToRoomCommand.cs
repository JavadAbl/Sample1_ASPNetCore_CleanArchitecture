using Application.Interfaces;
using Domain.Dto.Guest;
using MediatR;

namespace Application.Domain.Rooms.Command;

public class AddGuestToRoomCommand(int roomId, int guestId) : IRequest<Result>
{
    public int RoomId { get; } = roomId;
    public int GuestId { get; } = guestId;
}

