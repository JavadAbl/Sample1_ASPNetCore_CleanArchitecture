
using AutoMapper;
using Domain.Dto;
using Domain.Repository;
using MediatR;

namespace Application.Domain.Guests.Query;

public class GetGuestByPassNumberQueryHanlder(IGuestRepository rep, IMapper mapper) : IRequestHandler<GetGuestByPassNumberQuery, GuestDto?>
{
    public async Task<GuestDto?> Handle(GetGuestByPassNumberQuery request, CancellationToken cancellationToken)
    {
        var guest = await rep.GetByPassNumberAsync(request.PassNumber);

        var guestDto = mapper.Map<GuestDto>(guest);

        return guestDto;
    }
}

