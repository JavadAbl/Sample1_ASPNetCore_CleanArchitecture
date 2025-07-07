using Application.Domain.Rooms.Query;
using Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/[controller]/[Action]")]
public class RoomController(IMediator mediator) : BaseApiController
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await mediator.Send(new GetAllRoomsQuery());
        return FromResult(rooms);
    }
}
