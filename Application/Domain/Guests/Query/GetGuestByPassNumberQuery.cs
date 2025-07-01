

using Domain.Dto;
using MediatR;

namespace Application.Domain.Guests.Query;

public class GetGuestByPassNumberQuery(string PassNumber) : IRequest<GuestDto?>
{
    public string PassNumber { get; } = PassNumber;
}

