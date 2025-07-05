using Domain.Repository;
using MediatR;

namespace Application.Domain.Guests.Command
{
    public class DeleteGuestByIdCommandHandler(IGuestRepository rep) : IRequestHandler<DeleteGuestByIdCommand, bool>
    {
        public async Task<bool> Handle(DeleteGuestByIdCommand request, CancellationToken cancellationToken)
        {
            return await rep.DeleteAsync(request.Id);
        }
    }
}
