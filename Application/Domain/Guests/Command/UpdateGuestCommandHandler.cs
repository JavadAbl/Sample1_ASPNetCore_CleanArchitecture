using MediatR;

namespace Application.Domain.Guests.Command;

public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, bool>
{
    public async Task<bool> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
    {
        return true;
    }
}
