namespace Domain.Entity;

public class Room
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int Bed { get; set; }
    public int Capacity { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Guest? User { get; set; }
    public int UserId { get; set; }

}

