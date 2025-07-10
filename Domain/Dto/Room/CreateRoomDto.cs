
using Domain.Enum;

namespace Domain.Dto.Room;

public record CreateRoomDto
{
    public int? Number { get; set; }
    public int? Bed { get; set; }
    public int? Capacity { get; set; }
    public Room_Type? Type { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}

