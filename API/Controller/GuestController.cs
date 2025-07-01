using Application.Domain.Guests.Command;
using Application.Domain.Guests.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class GuestController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var guest = await mediator.Send(new GetGuestByIdQuery(id));
        if (guest == null)
            return NotFound("User not found");

        return Ok(guest);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var guests = await mediator.Send(new GetAllGuestsQuery());

        return Ok(guests);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGuestCommand command)
    {

        var existingGuest = await mediator.Send(new GetGuestByPassNumberQuery(command.PassNumber!));
        if (existingGuest != null)
        {
            throw new InvalidOperationException($"Guest with pass number {command.PassNumber} already exists.");
        }

        var guestId = await mediator.Send(command);
        return Created(string.Empty, guestId);
    }
}

