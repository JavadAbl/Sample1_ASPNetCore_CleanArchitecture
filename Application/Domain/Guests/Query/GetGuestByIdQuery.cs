using Domain.Dto.Guest;
using MediatR;

namespace Application.Domain.Guests.Query;

public class GetGuestByIdQuery(int Id) : IRequest<GuestDto?>
{
    public int Id { get; } = Id;
}

