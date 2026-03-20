namespace EventEase.Models;

public class Attendee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Company { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool HasAttended { get; set; }
    public DateTime? AttendanceMarkedDate { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}
