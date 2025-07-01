using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Domain.Guests.Command
{
    public class CreateGuestCommandHandler(IGuestRepository rep, IMapper mapper) : IRequestHandler<CreateGuestCommand, int>
    {
        public async Task<int> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = mapper.Map<Guest>(request);
            var id = await rep.AddAsync(guest);
            return id;
        }
    }
}
