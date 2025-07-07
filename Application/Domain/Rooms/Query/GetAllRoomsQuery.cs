using Application.Interfaces;
using Domain.Dto;
using MediatR;

namespace Application.Domain.Rooms.Query;

public class GetAllRoomsQuery : IRequest<Result<IEnumerable<RoomDto>>>;

