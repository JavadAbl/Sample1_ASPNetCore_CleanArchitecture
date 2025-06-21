using Domain.Entity;

namespace Domain.Dto;

public class CreateGuestDto
{
    public required string Username { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public Guest_Address? Address { get; set; }

}

