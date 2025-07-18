using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Domain.Rooms.Command;

public class AddGuestToRoomCommandHandler(IRoomRepository rep, IGuestRepository repGuest) : IRequestHandler<AddGuestToRoomCommand, Result>
{
    public async Task<Result> Handle(AddGuestToRoomCommand request, CancellationToken cancellationToken)
    {

        var room = await rep.GetByIdAsync(request.RoomId);
        if (room == null)
            return Result.Fail($"room with id {request.RoomId} not exists", (int)HttpStatusCode.Conflict);
        if (room.Guest != null)
            return Result.Fail($"room with id {request.RoomId} alraedy has a guest", (int)HttpStatusCode.Conflict);

        var guest = await repGuest.GetByIdAsync(request.GuestId);
        if (guest == null)
            return Result.Fail($"guest with id {request.GuestId} not exists", (int)HttpStatusCode.Conflict);

        guest.RoomId = room.Id;
        room.Guest = guest;
        await rep.SaveChnagesAsync();
        return Result.Created();
    }
}

