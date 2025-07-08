using Application.Domain.Guests.Command;
using Application.Domain.Guests.Query;
using Application.Domain.Guests.Validator;
using AutoMapper;
using Domain.Dto.Guest;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;


public class GuestController(IMediator mediator, IMapper mapper) : BaseApiController
{
    //--------------------------------------------------------------------
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var guest = await mediator.Send(new GetGuestByIdQuery(id));

        if (guest == null)
            return NotFound("User not found");

        return Ok(guest);
    }

    //--------------------------------------------------------------------
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var guests = await mediator.Send(new GetAllGuestsQuery());

        return Ok(guests);
    }

    //--------------------------------------------------------------------
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGuestDto dto)
    {
        var existingGuest = await mediator.Send(new GetGuestByPassNumberQuery(dto.PassNumber!));

        if (existingGuest != null)
            return Problem(detail: $"Guest with pass number {dto.PassNumber} already exists.", statusCode: StatusCodes.Status409Conflict);

        var command = mapper.Map<CreateGuestCommand>(dto);
        var guestId = await mediator.Send(command);
        return Created(string.Empty, guestId);
    }

    //--------------------------------------------------------------------
    [HttpPost("{id}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        var isDeleted = await mediator.Send(new DeleteGuestByIdCommand(id));

        if (!isDeleted)
            return Problem(statusCode: StatusCodes.Status400BadRequest, detail: $"Guest with id {id} not found");

        return NoContent();
    }

    //--------------------------------------------------------------------
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGuestDto dto)
    {
        var result = await mediator.Send(mapper.Map<UpdateGuestCommand>(dto));

        return result.Success switch
        {
            false => Problem(statusCode: result.StatusCode ?? 500, detail: result.Error),
            true => NoContent()
        };
    }
}