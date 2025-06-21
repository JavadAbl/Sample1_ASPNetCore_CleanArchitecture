using Domain.Entity;
using Domain.Enum;
using Infrastructure.Interfaces;

namespace Infrastructure.Database;

internal class Seeder(AppDbContext dbContext) : ISeeder
{
    public void SeedAppDb()
    {

        if (!dbContext.Rooms.Any())
        {
            dbContext.Rooms.AddRange(GetRooms());
            dbContext.SaveChanges();
        }

        if (!dbContext.Guests.Any())
        {
            dbContext.Guests.AddRange(GetGuests());
            dbContext.SaveChanges();
        }
    }


    private Room[] GetRooms()
    {
        return new Room[]
        {
        new Room
        {
            Number = 101,
            Bed = 1,
            Capacity = 1,
            Type = Room_Type.Single,
            Description = "Cozy single room with a city view.",
            Price = 75.00m
        },
        new Room
        {
            Number = 102,
            Bed = 2,
            Capacity = 2,
            Type = Room_Type.Double,
            Description = "Spacious double room with two beds.",
            Price = 120.00m
        },
        new Room
        {
            Number = 201,
            Bed = 1,
            Capacity = 2,
            Type = Room_Type.Suite,
            Description = "Luxury suite with a queen bed and balcony.",
            Price = 250.00m
        },
        new Room
        {
            Number = 202,
            Bed = 2,
            Capacity = 4,
            Type = Room_Type.Family,
            Description = "Family room with two double beds and kitchenette.",
            Price = 180.00m
        },
        new Room
        {
            Number = 301,
            Bed = 1,
            Capacity = 2,
            Type = Room_Type.Deluxe,
            Description = "Deluxe room with premium amenities and ocean view.",
            Price = 220.00m
        }
        };
    }


    private Guest[] GetGuests()
    {
        return new Guest[]
        {
        new Guest
        {
            PassNumber = "A123456789",
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Mobile = "+1234567890",
            Address = new Guest_Address
            {
                Street = "123 Elm Street",
                City = "Springfield",
                State = "IL",
                PostalCode = "62704",
                Country = "USA"
            }
        },
        new Guest
        {
            PassNumber = "B987654321",
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane.smith@example.com",
            Mobile = "+1987654321",
            Address = new Guest_Address
            {
                Street = "456 Oak Avenue",
                City = "Greenville",
                State = "TX",
                PostalCode = "75401",
                Country = "USA"
            }
        },
        new Guest
        {
            PassNumber = "C555444333",
            FirstName = "Ali",
            LastName = "Rezaei",
            Email = "ali.rezaei@example.com",
            Mobile = "+989123456789",
            Address = new Guest_Address
            {
                Street = "789 Tehran St",
                City = "Tehran",
                State = "Tehran",
                PostalCode = "1234567890",
                Country = "Iran"
            }
        },
        new Guest
        {
            PassNumber = "D111222333",
            FirstName = "Sara",
            LastName = "Karimi"
        },
        new Guest
        {
            PassNumber = "E444555666",
            FirstName = "Mehdi",
            LastName = "Ahmadi"
        }
        };
    }

}

