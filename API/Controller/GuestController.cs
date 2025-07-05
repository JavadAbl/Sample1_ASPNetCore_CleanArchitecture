using Application.Domain.Guests.Command;
using Application.Domain.Guests.Query;
using Application.Domain.Guests.Validator;
using FluentValidation;
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
    public async Task<IActionResult> Create([FromBody] CreateGuestDto dto)
    {
        var existingGuest = await mediator.Send(new GetGuestByPassNumberQuery(dto.PassNumber!));

        if (existingGuest != null)
            return Conflict($"Guest with pass number {dto.PassNumber} already exists.");

        CreateGuestCommand command = (CreateGuestCommand)dto;
        var guestId = await mediator.Send(command);
        return Created(string.Empty, guestId);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        var isDeleted = await mediator.Send(new DeleteGuestByIdCommand(id));

        if (!isDeleted)
            return Problem(statusCode: StatusCodes.Status400BadRequest, detail: $"Guest with id {id} not found");

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update()
    {


        return NoContent();
    }
}