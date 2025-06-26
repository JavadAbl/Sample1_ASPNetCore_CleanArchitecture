using Application.Interfaces;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class GuestController(IGuestService service) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var guest = await service.GetById(id);
        if (guest == null)
            return NotFound();

        return Ok(guest);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGuest([FromBody] CreateGuestDto createGuestDto)
    {
        var guestId = await service.Add(createGuestDto);
        return Created("", guestId);
    }
}

