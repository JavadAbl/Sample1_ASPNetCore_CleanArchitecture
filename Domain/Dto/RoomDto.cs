using Domain.Entity;
using Domain.Enum;

namespace Domain.Dto;

public class RoomDto
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int Bed { get; set; }
    public int Capacity { get; set; }
    public Room_Type Type { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guest? Guest { get; set; }

    public ICollection<RoomCleaner> RoomCleaners { get; set; } = [];
}

