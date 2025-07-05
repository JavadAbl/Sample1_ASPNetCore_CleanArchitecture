

using Domain.Entity;
using MediatR;

namespace Application.Domain.Guests.Command;
public class UpdateGuestCommand : IRequest<bool>
{
    public int? Id { get; set; }
    public string? PassNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public Guest_Address? Address { get; set; }
    public int? RoomId { get; set; }


}


