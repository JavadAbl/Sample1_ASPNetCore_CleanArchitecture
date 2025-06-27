using Domain.Entity;

namespace Domain.Dto;

public class CreateGuestDto
{
    public string? PassNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public Guest_Address? Address { get; set; }

}

