namespace EventEase.Models;

public class EventItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string FullDescription { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int AvailableSpots { get; set; }
    public string Price { get; set; } = string.Empty;
    public List<Attendee> Attendees { get; set; } = new();

    // Cached formatted date to avoid recalculating on every render
    private string? _formattedDate;
    public string FormattedDate => _formattedDate ??= Date.ToString("MMM dd, yyyy");

    private string? _formattedDateLong;
    public string FormattedDateLong => _formattedDateLong ??= Date.ToString("MMMM dd, yyyy");

    // Attendance tracking properties
    public int TotalRegistrations => Attendees.Count;
    public int AttendanceCount => Attendees.Count(a => a.HasAttended);
    public int NotAttendedCount => Attendees.Count(a => !a.HasAttended);
    public double AttendanceRate => TotalRegistrations > 0 
        ? Math.Round((double)AttendanceCount / TotalRegistrations * 100, 1) 
        : 0;
}
