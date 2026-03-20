namespace EventEase.Models;

public class UserSession
{
    public string SessionId { get; set; } = Guid.NewGuid().ToString();
    public DateTime SessionStart { get; set; } = DateTime.Now;
    public DateTime? SessionEnd { get; set; }
    public List<PageView> PageViews { get; set; } = new();
    public string? UserAgent { get; set; }
    public string? IpAddress { get; set; }
    
    public TimeSpan SessionDuration => SessionEnd.HasValue 
        ? SessionEnd.Value - SessionStart 
        : DateTime.Now - SessionStart;
    
    public int TotalPageViews => PageViews.Count;
    
    public int UniquePageViews => PageViews.Select(pv => pv.PageUrl).Distinct().Count();
    
    public PageView? CurrentPage => PageViews.LastOrDefault();
    
    public PageView? MostVisitedPage => PageViews
        .GroupBy(pv => pv.PageUrl)
        .OrderByDescending(g => g.Count())
        .FirstOrDefault()
        ?.FirstOrDefault();
    
    public double AverageTimePerPage => PageViews.Any() 
        ? PageViews.Average(pv => pv.TimeSpentSeconds) 
        : 0;
}
