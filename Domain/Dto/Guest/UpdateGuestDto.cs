
using Domain.Entity;

namespace Domain.Dto.Guest;

public record UpdateGuestDto
{
    public int Id { get; set; }
    public string? PassNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public Guest_Address? Address { get; set; }
}

