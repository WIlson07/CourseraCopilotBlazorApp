using EventEase.Models;
using Microsoft.JSInterop;

namespace EventEase.Services;

public class SessionService
{
    private readonly IJSRuntime _jsRuntime;
    private UserSession _currentSession;
    private PageView? _currentPageView;
    private Timer? _autoSaveTimer;
    
    public event Action? OnSessionUpdated;
    
    public SessionService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        _currentSession = new UserSession();
        
        // Auto-save session every 30 seconds
        _autoSaveTimer = new Timer(AutoSaveCallback, null, TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(30));
    }
    
    public UserSession CurrentSession => _currentSession;
    
    public async Task InitializeSessionAsync()
    {
        try
        {
            // Try to load existing session from localStorage
            var sessionJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "userSession");
            
            if (!string.IsNullOrEmpty(sessionJson))
            {
                var savedSession = System.Text.Json.JsonSerializer.Deserialize<UserSession>(sessionJson);
                if (savedSession != null && savedSession.SessionEnd == null)
                {
                    _currentSession = savedSession;
                }
            }
        }
        catch (Exception)
        {
            // If deserialization fails, start a new session
            _currentSession = new UserSession();
        }
        
        await SaveSessionAsync();
        NotifySessionUpdated();
    }
    
    public async Task TrackPageViewAsync(string pageUrl, string pageTitle, string? referrerUrl = null)
    {
        // End the previous page view if exists
        if (_currentPageView != null)
        {
            _currentPageView.ViewEnd = DateTime.Now;
        }
        
        // Create new page view
        _currentPageView = new PageView
        {
            PageUrl = pageUrl,
            PageTitle = pageTitle,
            ViewStart = DateTime.Now,
            ReferrerUrl = referrerUrl
        };
        
        _currentSession.PageViews.Add(_currentPageView);
        
        await SaveSessionAsync();
        NotifySessionUpdated();
    }
    
    public async Task EndSessionAsync()
    {
        if (_currentPageView != null)
        {
            _currentPageView.ViewEnd = DateTime.Now;
        }
        
        _currentSession.SessionEnd = DateTime.Now;
        await SaveSessionAsync();
        NotifySessionUpdated();
    }
    
    public async Task ResetSessionAsync()
    {
        await EndSessionAsync();
        _currentSession = new UserSession();
        _currentPageView = null;
        await SaveSessionAsync();
        NotifySessionUpdated();
    }
    
    public List<UserSession> GetAllSessions()
    {
        // In a real app, this would fetch from a database
        // For now, return current session only
        return new List<UserSession> { _currentSession };
    }
    
    public Dictionary<string, int> GetPageViewStatistics()
    {
        return _currentSession.PageViews
            .GroupBy(pv => pv.PageTitle)
            .ToDictionary(g => g.Key, g => g.Count());
    }
    
    public List<PageView> GetRecentPageViews(int count = 10)
    {
        return _currentSession.PageViews
            .OrderByDescending(pv => pv.ViewStart)
            .Take(count)
            .ToList();
    }
    
    private async Task SaveSessionAsync()
    {
        try
        {
            var sessionJson = System.Text.Json.JsonSerializer.Serialize(_currentSession);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "userSession", sessionJson);
        }
        catch (Exception)
        {
            // Silently fail if localStorage is not available
        }
    }
    
    private void AutoSaveCallback(object? state)
    {
        Task.Run(async () => await SaveSessionAsync());
    }
    
    private void NotifySessionUpdated()
    {
        OnSessionUpdated?.Invoke();
    }
    
    public void Dispose()
    {
        _autoSaveTimer?.Dispose();
    }
}
