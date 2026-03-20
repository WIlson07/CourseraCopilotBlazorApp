using EventEase.Models;

namespace EventEase.Services;

public class EventService
{
    private readonly List<EventItem> _events;
    private int _nextAttendeeId = 1;

    public EventService()
    {
        // Initialize sample events data
        _events = new List<EventItem>
        {
            new EventItem
            {
                Id = 1,
                Title = "Tech Conference 2026",
                Description = "Annual technology conference featuring the latest innovations.",
                FullDescription = "Join us for three days of cutting-edge technology presentations, workshops, and networking opportunities. Hear from industry leaders, participate in hands-on sessions, and discover the latest trends in software development, AI, cloud computing, and more.",
                Date = new DateTime(2026, 4, 15),
                Location = "San Francisco, CA",
                Duration = "3 days",
                Capacity = 500,
                AvailableSpots = 127,
                Price = "$299"
            },
            new EventItem
            {
                Id = 2,
                Title = "Blazor Workshop",
                Description = "Hands-on workshop for Blazor development and best practices.",
                FullDescription = "Deep dive into Blazor development with this comprehensive workshop. Learn component architecture, state management, routing, dependency injection, and deployment strategies. Build a complete application from scratch with expert guidance.",
                Date = new DateTime(2026, 5, 20),
                Location = "Seattle, WA",
                Duration = "1 day (8 hours)",
                Capacity = 50,
                AvailableSpots = 12,
                Price = "$199"
            },
            new EventItem
            {
                Id = 3,
                Title = "Developer Meetup",
                Description = "Monthly meetup for local developers to network and share ideas.",
                FullDescription = "Connect with fellow developers in your area! Share your experiences, learn from others, and build your professional network. This month's topics include modern web development, DevOps practices, and career growth strategies.",
                Date = new DateTime(2026, 4, 5),
                Location = "Austin, TX",
                Duration = "3 hours",
                Capacity = 100,
                AvailableSpots = 43,
                Price = "Free"
            },
            new EventItem
            {
                Id = 4,
                Title = ".NET Summit",
                Description = "Conference dedicated to .NET technologies and frameworks.",
                FullDescription = "The premier conference for .NET developers! Explore the latest in .NET 10, C# 14, ASP.NET Core, Entity Framework, and more. Sessions cover everything from beginner to advanced topics, with tracks for web, mobile, desktop, and cloud development.",
                Date = new DateTime(2026, 6, 10),
                Location = "Boston, MA",
                Duration = "2 days",
                Capacity = 800,
                AvailableSpots = 0,
                Price = "$399"
            },
            new EventItem
            {
                Id = 5,
                Title = "Cloud Computing Expo",
                Description = "Explore the latest trends in cloud computing and infrastructure.",
                FullDescription = "Discover the future of cloud computing! Learn about multi-cloud strategies, serverless architectures, Kubernetes, infrastructure as code, and cloud security. Network with cloud architects and engineers from leading companies.",
                Date = new DateTime(2026, 7, 22),
                Location = "New York, NY",
                Duration = "2 days",
                Capacity = 1000,
                AvailableSpots = 234,
                Price = "$449"
            },
            new EventItem
            {
                Id = 6,
                Title = "Web Design Conference",
                Description = "Discover modern web design techniques and UI/UX best practices.",
                FullDescription = "Transform your design skills at this comprehensive conference. Topics include responsive design, accessibility, design systems, user research, prototyping, and the latest CSS features. Get inspired by award-winning designers and ship better products.",
                Date = new DateTime(2026, 8, 12),
                Location = "Los Angeles, CA",
                Duration = "3 days",
                Capacity = 300,
                AvailableSpots = 89,
                Price = "$349"
            }
        };

        // Add sample attendees to demonstrate attendance tracking
        AddSampleAttendees();
    }

    private void AddSampleAttendees()
    {
        // Add sample attendees to event 1
        var event1 = _events[0];
        event1.Attendees.Add(new Attendee 
        { 
            Id = _nextAttendeeId++, 
            FirstName = "John", 
            LastName = "Doe", 
            Email = "john.doe@example.com",
            Phone = "(555) 123-4567",
            Company = "Tech Corp",
            RegistrationDate = DateTime.Now.AddDays(-5),
            HasAttended = true,
            AttendanceMarkedDate = DateTime.Now.AddDays(-1)
        });
        event1.Attendees.Add(new Attendee 
        { 
            Id = _nextAttendeeId++, 
            FirstName = "Jane", 
            LastName = "Smith", 
            Email = "jane.smith@example.com",
            Phone = "(555) 234-5678",
            Company = "Innovate Inc",
            RegistrationDate = DateTime.Now.AddDays(-3),
            HasAttended = true,
            AttendanceMarkedDate = DateTime.Now.AddDays(-1)
        });
        event1.Attendees.Add(new Attendee 
        { 
            Id = _nextAttendeeId++, 
            FirstName = "Michael", 
            LastName = "Johnson", 
            Email = "michael.j@example.com",
            RegistrationDate = DateTime.Now.AddDays(-2),
            HasAttended = false
        });

        // Add sample attendees to event 2
        var event2 = _events[1];
        event2.Attendees.Add(new Attendee 
        { 
            Id = _nextAttendeeId++, 
            FirstName = "Sarah", 
            LastName = "Williams", 
            Email = "sarah.w@example.com",
            Company = "Dev Solutions",
            RegistrationDate = DateTime.Now.AddDays(-7),
            HasAttended = true,
            AttendanceMarkedDate = DateTime.Now.AddDays(-2)
        });
        event2.Attendees.Add(new Attendee 
        { 
            Id = _nextAttendeeId++, 
            FirstName = "David", 
            LastName = "Brown", 
            Email = "david.brown@example.com",
            RegistrationDate = DateTime.Now.AddDays(-4),
            HasAttended = false
        });
    }

    public IReadOnlyList<EventItem> GetAllEvents()
    {
        return _events.AsReadOnly();
    }

    public EventItem? GetEventById(int id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }

    public IReadOnlyList<EventItem> GetUpcomingEvents()
    {
        var today = DateTime.Today;
        return _events
            .Where(e => e.Date >= today)
            .OrderBy(e => e.Date)
            .ToList()
            .AsReadOnly();
    }

    public bool RegisterForEvent(int eventId, string firstName, string lastName, string email, string? phone = null, string? company = null)
    {
        var eventItem = _events.FirstOrDefault(e => e.Id == eventId);
        if (eventItem != null && eventItem.AvailableSpots > 0)
        {
            var attendee = new Attendee
            {
                Id = _nextAttendeeId++,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Company = company,
                RegistrationDate = DateTime.Now,
                HasAttended = false
            };

            eventItem.Attendees.Add(attendee);
            eventItem.AvailableSpots--;
            return true;
        }
        return false;
    }

    public bool MarkAttendance(int eventId, int attendeeId, bool hasAttended)
    {
        var eventItem = _events.FirstOrDefault(e => e.Id == eventId);
        var attendee = eventItem?.Attendees.FirstOrDefault(a => a.Id == attendeeId);
        
        if (attendee != null)
        {
            attendee.HasAttended = hasAttended;
            attendee.AttendanceMarkedDate = hasAttended ? DateTime.Now : null;
            return true;
        }
        return false;
    }

    public IReadOnlyList<Attendee> GetEventAttendees(int eventId)
    {
        var eventItem = _events.FirstOrDefault(e => e.Id == eventId);
        return eventItem?.Attendees.AsReadOnly() ?? new List<Attendee>().AsReadOnly();
    }

    public bool RemoveAttendee(int eventId, int attendeeId)
    {
        var eventItem = _events.FirstOrDefault(e => e.Id == eventId);
        var attendee = eventItem?.Attendees.FirstOrDefault(a => a.Id == attendeeId);
        
        if (eventItem != null && attendee != null)
        {
            eventItem.Attendees.Remove(attendee);
            eventItem.AvailableSpots++;
            return true;
        }
        return false;
    }
}
