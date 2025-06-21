

namespace Domain.Entity;

public class Guest
{
    public int Id { get; set; }
    public required string PassNumber { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Guest_Address? Address { get; set; }





}

