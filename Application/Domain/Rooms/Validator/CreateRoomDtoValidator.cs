using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dto.Room;
using Domain.Enum;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Domain.Rooms.Validator;

public class CreateRoomDtoValidator : AbstractValidator<CreateRoomDto>
{
    public CreateRoomDtoValidator()
    {
        RuleFor(r => r.Number).NotEmpty().WithMessage("Number is required.");
        RuleFor(r => r.Bed).NotEmpty().WithMessage("Bed is required.");
        RuleFor(r => r.Capacity).NotEmpty().WithMessage("Capacity is required.");
        RuleFor(r => r.Price).NotEmpty().WithMessage("Price is required.");
        RuleFor(r => r.Type).NotEmpty().IsInEnum().WithMessage("Type is required.");
    }
}

