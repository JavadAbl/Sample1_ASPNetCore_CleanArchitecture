using Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/[controller]")]
public class GuestController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        // This is a placeholder for the actual implementation
        return Ok("List of users");
    }

    [HttpPost]
    public IActionResult CreateGuest([FromBody] CreateGuestDto guestDto)
    {
        if (guestDto == null)
        {
            return BadRequest("User data is required.");
        }
        // This is a placeholder for the actual implementation
        return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
    }
}

