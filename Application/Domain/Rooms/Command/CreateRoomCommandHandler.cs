using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Domain.Rooms.Command;

public class CreateRoomCommandHandler(IRoomRepository rep, IMapper mapper) : IRequestHandler<CreateRoomCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var existingRoom = await rep.GetByNumberAsync(dto.Number!.Value);
        if (existingRoom != null)
            return Result<int>.Fail($"room with number {dto.Number} exists", (int)HttpStatusCode.Conflict);

        var room = mapper.Map<Room>(dto);
        var roomId = await rep.AddAsync(room);
        return Result<int>.Created(roomId);
    }
}

