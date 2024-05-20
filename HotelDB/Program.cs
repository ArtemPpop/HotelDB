using Microsoft.EntityFrameworkCore;
using System;
public class ModelDB : DbContext
{
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Guest> Guests { get; set; } = null!;
    public DbSet<Stay> Stays { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public ModelDB()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=hotelDB.db");
    }

}
public class Room
{
    public int Id { get; set; }
    public string? RoomType { get; set; }
    public decimal? Price { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public List<Stay> Stays { get; set; } = new();
}

public class Guest
{
    public int Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Patronymic { get; set; }
    public string? Passport { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public List<Stay> Stays { get; set; } = new();
}

public class Stay
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string? Status { get; set; }
    public Payment? Payment { get; set; }
    public Room? Room { get; set; }
    public Guest? Guest { get; set; }
}

public class Payment
{
    public int Id { get; set; }
    public int StayId { get; set; }
    public Stay? Stay { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
}

public class Employee
{
    public int Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Patronymic { get; set; }
    public string? Position { get; set; }
    public string? Phone { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
}
