namespace Client.Services;


public sealed class DateChangeService : IDisposable
{
  
  private readonly Timer _timer;

  public event Action? DateChanged;

  public DateChangeService()
  {
    
    DateTime localNow = DateTime.Now;
    DateTime nextLocalMidnight = localNow.Date.AddDays(1);
    TimeSpan remainTimeUntilLocalTomorrow = nextLocalMidnight - localNow;

    this._timer =
      
        new Timer(
          this.OnTimerElapsed, 
          state: null,
          remainTimeUntilLocalTomorrow,
          period: TimeSpan.FromDays(1)
        );
    
  }

  private void OnTimerElapsed(object? state)
  {
    this.DateChanged?.Invoke();
  }

  public void Dispose()
  {
    this._timer.Dispose();
  }
  
}