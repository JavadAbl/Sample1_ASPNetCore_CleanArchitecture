using Domain.Entity;
using MediatR;

namespace Application.Domain.Guests.Command
{
    public class DeleteGuestByIdCommand(int Id) : IRequest<bool>
    {
        public int Id { get; } = Id;
    }
}
