# EventEase

A modern event management application built with Blazor WebAssembly, featuring event registration, attendance tracking, and comprehensive user session analytics.

Copilot helped me create every component of this app by improving it in each activity of this unit. I read every line it created as well as the description of why it added it.

## 🌟 Features

### Event Management
- **Event Listings**: Browse all available events with detailed information
- **Event Details**: View comprehensive event information including date, location, capacity, and pricing
- **Event Registration**: Register for events with a user-friendly form
- **Available Spots Tracking**: Real-time tracking of event capacity and available spots
2
### Attendance Tracking
- **Attendee Management**: Track all registered attendees for each event
- **Attendance Status**: Mark attendees as present or absent with one-click actions
- **Attendance Statistics**: 
  - Total registrations
  - Attendance count
  - Not attended count
  - Attendance rate percentage
- **Search & Filter**: Find attendees by name, email, or company
- **Attendee Details**: View complete registration information including contact details
- **Remove Registrations**: Manage attendee list with delete functionality

### User Session Tracking
- **Real-time Session Monitoring**: Floating pill displaying live session duration and page view count
- **Session Dashboard**: Comprehensive analytics including:
  - Session duration tracking
  - Total and unique page views
  - Average time per page
  - Most visited page statistics
  - Current page tracking with time spent
  - Page view statistics with visual bar charts
  - Recent page views history
  - Navigation timeline with complete journey visualization
- **Session Persistence**: Session data saved to localStorage (survives page refresh)
- **Session Management**: Reset session functionality

## 🚀 Getting Started

### Prerequisites
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- A modern web browser (Chrome, Firefox, Edge, Safari)

### Installation

1. Clone the repository:
```bash
git clone <repository-url>
cd EventEase
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

### Running the Application

**Development mode with hot reload:**
```bash
dotnet watch run
```

**Standard run:**
```bash
dotnet run
```

The application will be available at `https://localhost:5001` (or the port shown in the console).

## 📁 Project Structure

```
EventEase/
├── Components/           # Reusable Blazor components
│   ├── EventCard.razor          # Event card display component
│   ├── SessionTracker.razor     # Background session tracking component
│   └── SessionInfo.razor        # Floating session info pill
├── Layout/              # Application layout components
│   ├── MainLayout.razor         # Main application layout
│   └── NavMenu.razor            # Navigation menu
├── Models/              # Data models
│   ├── EventItem.cs             # Event data model
│   ├── Attendee.cs              # Attendee information model
│   ├── UserSession.cs           # User session tracking model
│   └── PageView.cs              # Page view tracking model
├── Pages/               # Page components (routes)
│   ├── Events.razor             # Event listing page
│   ├── EventDetails.razor       # Event details and attendance tracker
│   ├── EventRegistration.razor  # Event registration form
│   └── SessionDashboard.razor   # Session analytics dashboard
├── Services/            # Business logic services
│   ├── EventService.cs          # Event and attendee management
│   └── SessionService.cs        # Session tracking and analytics
├── wwwroot/             # Static files (CSS, JS, images)
├── Program.cs           # Application entry point
└── App.razor            # Root component with routing
```

## 🛠️ Technologies Used

- **Blazor WebAssembly**: Client-side web framework using C# and .NET
- **.NET 10.0**: Latest .NET framework
- **Bootstrap 5**: Responsive UI framework
- **Bootstrap Icons**: Icon library
- **LocalStorage API**: Client-side data persistence
- **C# 12**: Modern C# language features

## 💡 Key Features Breakdown

### Event Card Component
Displays event summary information in a card format with:
- Event title and description
- Date and location
- Available spots indicator
- Quick navigation to details and registration

### Attendance Tracker
Integrated into the Event Details page with:
- Statistical overview cards
- Searchable and filterable attendee list
- Toggle view for compact display
- Quick action buttons for attendance marking
- Color-coded status indicators
- Responsive table design

### Session Dashboard
Comprehensive analytics dashboard featuring:
- 4 statistical overview cards
- Real-time current page tracking
- Page view statistics with progress bars
- Recent activity timeline
- Complete navigation journey visualization
- Session metadata display
- Refresh and reset controls

### Session Info Pill
Floating UI element providing:
- Live session duration counter
- Total page view count
- Quick access to session dashboard
- Gradient purple design
- Responsive mobile layout

## 📊 Sample Data

The application comes pre-loaded with 6 sample events:
1. Tech Conference 2026
2. Blazor Workshop
3. Developer Meetup
4. .NET Summit
5. Cloud Computing Expo
6. Web Design Conference

Sample attendees are included on events 1 and 2 to demonstrate the attendance tracking feature.

## 🎨 Styling

The application uses:
- Bootstrap 5 for responsive grid and components
- Custom CSS for specialized components (session pill, timeline)
- Scoped CSS for component-specific styling
- Bootstrap Icons for consistent iconography
- Gradient backgrounds for visual appeal

## 🔧 Configuration

### Service Registration
Services are registered in `Program.cs`:
- `EventService`: Singleton for event data management
- `SessionService`: Scoped for user session tracking

### Component Integration
Key components are integrated in `MainLayout.razor`:
- SessionTracker (invisible background tracker)
- SessionInfo (floating UI pill)

## 📝 Future Enhancements

Potential features for future development:
- User authentication and authorization
- Backend API integration with database
- Export attendance reports to CSV/PDF
- Email notifications for registrations
- Calendar integration
- Event categories and filtering
- Advanced search functionality
- Multi-session support
- Session comparison analytics
- Mobile app version

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is part of the Coursera Blazor for Front-End Development course.

## 👤 Author

Created as part of the Copilot for Blazor Development course.

## 🙏 Acknowledgments

- Microsoft for Blazor framework
- Bootstrap team for the UI framework
- Coursera for the learning platform

---

**Note**: This is a learning project demonstrating Blazor WebAssembly capabilities with event management, attendance tracking, and session analytics features.
