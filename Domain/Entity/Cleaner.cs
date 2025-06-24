
namespace Domain.Entity;

public class Cleaner
{
    public int Id { get; set; }
    public required int Code { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public ICollection<Room> Rooms { get; set; } = [];
}
