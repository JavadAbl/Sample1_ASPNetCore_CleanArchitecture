
namespace Domain.Dto.Room;

public record AddGuestToRoomDto
{
    public int? RoomId { get; set; }
    public int? GuestId { get; set; }
}

