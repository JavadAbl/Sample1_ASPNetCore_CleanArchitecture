﻿using Domain.Entity;

namespace Domain.Dto.Guest;

public record GuestDto
{
    public int Id { get; set; }
    public required string PassNumber { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public Guest_Address? Address { get; set; }

    public RoomSummaryDto? Room { get; set; }
    //   public RoomDto? Room { get; set; }
}

