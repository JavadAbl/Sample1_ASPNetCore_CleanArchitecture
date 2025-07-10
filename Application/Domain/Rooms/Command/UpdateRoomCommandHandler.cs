using System.Net;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Domain.Rooms.Command;

public class UpdateRoomCommandHandler(IRoomRepository rep, IMapper mapper) : IRequestHandler<UpdateRoomCommand, Result>
{
    public async Task<Result> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var existingRoom = await rep.GetByNumberAsync(dto.Number!.Value);
        if (existingRoom == null)
            return Result.Fail($"room with number {dto.Number} not exists", (int)HttpStatusCode.NotFound);

        mapper.Map(dto, existingRoom);
        await rep.SaveChnagesAsync();
        return Result.NoContent();
    }
}

