using System.Net;
using Application.Interfaces;
using AutoMapper;
using Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Domain.Guests.Command;

public class UpdateGuestCommandHandler(IGuestRepository rep, IMapper mapper, ILogger<UpdateGuestCommandHandler> logger) : IRequestHandler<UpdateGuestCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
    {
        var guest = await rep.GetByIdAsync(request.Id);
        if (guest == null)
            return Result<Unit>.Fail($"Guest with id {request.Id} not found", ((int)HttpStatusCode.NotFound));

        mapper.Map(request, guest);

        await rep.SaveChnagesAsync();
        return Result<Unit>.NoContent();

    }
}
