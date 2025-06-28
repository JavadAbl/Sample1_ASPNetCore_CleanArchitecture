using Application.Interfaces;
using Domain.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class GuestController(IGuestService service, IValidator<CreateGuestDto> validator) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var guest = await service.GetById(id);
        if (guest == null)
            return NotFound("User not found");

        return Ok(guest);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var guests = await service.GetAll();

        return Ok(guests);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGuestDto createGuestDto)
    {

        /*    var result = await validator.ValidateAsync(createGuestDto);*/
        return Ok(1);

        var guestId = await service.Add(createGuestDto);
        return Created(string.Empty, guestId);
    }
}

