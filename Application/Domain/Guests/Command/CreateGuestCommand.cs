using Domain.Entity;
using MediatR;

namespace Application.Domain.Guests.Command
{
    public class CreateGuestCommand : IRequest<int>
    {
        public string? PassNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public Guest_Address? Address { get; set; }
    }
}
