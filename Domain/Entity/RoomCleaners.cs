
namespace Domain.Entity;

public class RoomCleaners
{
    public int RoomId { get; set; }
    public required Room Room { get; set; }
    public int CleanerId { get; set; }
    public required Cleaner Cleaner { get; set; }

}