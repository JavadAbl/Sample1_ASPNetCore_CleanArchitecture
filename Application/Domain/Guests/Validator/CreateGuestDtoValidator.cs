﻿using Domain.Dto.Guest;
using FluentValidation;

namespace Application.Domain.Guests.Validator;

public class CreateGuestDtoValidator : AbstractValidator<CreateGuestDto>
{
    public CreateGuestDtoValidator()
    {
        RuleFor(x => x.PassNumber)
            .NotEmpty().WithMessage("PassNumber is required.")
            .Length(5, 20).WithMessage("Pass number must be between 5 and 20 characters.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required2.")
            .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Invalid email format.")
            .When(x => !string.IsNullOrEmpty(x.Email));

    }

}

