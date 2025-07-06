using Domain.Dto.Guest;
using MediatR;

namespace Application.Domain.Guests.Query
{
    public class GetAllGuestsQuery : IRequest<IEnumerable<GuestDto>>;
}
