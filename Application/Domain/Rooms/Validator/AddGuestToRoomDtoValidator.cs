using Domain.Dto.Room;
using FluentValidation;


namespace Application.Domain.Rooms.Validator;

public class AddGuestToRoomDtoValidator : AbstractValidator<AddGuestToRoomDto>
{
    public AddGuestToRoomDtoValidator()
    {
        RuleFor(r => r.RoomId).NotEmpty().WithMessage("RoomId is required.");
        RuleFor(r => r.GuestId).NotEmpty().WithMessage("GuestId is required.");
    }
}

