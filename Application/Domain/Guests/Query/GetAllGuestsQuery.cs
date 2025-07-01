using Domain.Dto;
using MediatR;

namespace Application.Domain.Guests.Query
{
    public class GetAllGuestsQuery : IRequest<IEnumerable<GuestDto>>;
}
