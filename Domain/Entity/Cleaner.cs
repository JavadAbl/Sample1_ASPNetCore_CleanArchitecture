

namespace Domain.Entity;

public record Cleaner : BaseEntity
{
    public int Id { get; set; }
    public required int Code { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public ICollection<RoomCleaner> RoomCleaners { get; set; } = [];
}
