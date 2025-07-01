using AutoMapper;
using Domain.Dto;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Domain.Guests.Query
{
    public class GetAllGuestsQueryHandler(IGuestRepository rep, IMapper mapper) : IRequestHandler<GetAllGuestsQuery, IEnumerable<GuestDto>>
    {
        public async Task<IEnumerable<GuestDto>> Handle(GetAllGuestsQuery request, CancellationToken cancellationToken)
        {
            var guests = await rep.GetAllAsync();
            var guestDtos = mapper.Map<IEnumerable<GuestDto>>(guests);
            return guestDtos;
        }
    }
}