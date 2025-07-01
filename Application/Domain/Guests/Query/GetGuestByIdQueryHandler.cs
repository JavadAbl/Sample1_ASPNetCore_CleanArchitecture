

using AutoMapper;
using Domain.Dto;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Domain.Guests.Query
{
    public class GetGuestByIdQueryHandler(IGuestRepository rep, IMapper mapper) : IRequestHandler<GetGuestByIdQuery, GuestDto?>
    {
        public async Task<GuestDto?> Handle(GetGuestByIdQuery request, CancellationToken cancellationToken)
        {
            var guest = await rep.GetByIdAsync(request.Id);
            var guestDto = mapper.Map<GuestDto>(guest);

            return guestDto;
        }
    }
}

