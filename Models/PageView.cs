namespace EventEase.Models;

public class PageView
{
    public string PageUrl { get; set; } = string.Empty;
    public string PageTitle { get; set; } = string.Empty;
    public DateTime ViewStart { get; set; } = DateTime.Now;
    public DateTime? ViewEnd { get; set; }
    public string? ReferrerUrl { get; set; }
    
    public double TimeSpentSeconds => ViewEnd.HasValue 
        ? (ViewEnd.Value - ViewStart).TotalSeconds 
        : (DateTime.Now - ViewStart).TotalSeconds;
    
    public string TimeSpentFormatted
    {
        get
        {
            var timeSpent = TimeSpan.FromSeconds(TimeSpentSeconds);
            if (timeSpent.TotalMinutes < 1)
                return $"{timeSpent.Seconds}s";
            else if (timeSpent.TotalHours < 1)
                return $"{timeSpent.Minutes}m {timeSpent.Seconds}s";
            else
                return $"{timeSpent.Hours}h {timeSpent.Minutes}m";
        }
    }
}
