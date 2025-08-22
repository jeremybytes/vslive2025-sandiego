using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiStopWatch;

/// <summary>
/// This class is a simple time ticker class.  Note: this
/// class is for the included demo only and would require
/// modifications before using in a production application
/// </summary>
public class Ticker : INotifyPropertyChanged
{
    private IDispatcherTimer timer;
    private TimeSpan currentInterval;
    private DateTime startTime;

    private string displayInterval = "00:00";
    public string DisplayInterval
    {
        get
        {
            return displayInterval;
        }
        set
        {
            if (displayInterval != value)
            {
                displayInterval = value;
                RaisePropertyChanged();
            }
        }
    }

    public Ticker(IDispatcherTimer dispatcherTimer)
    {
        timer = dispatcherTimer;
        timer.Interval = new(0, 0, 0, 0, 100);
        timer.Tick += Timer_Tick;
    }

    public void Start()
    {
        if (!timer.IsRunning)
        {
            startTime = DateTime.Now - currentInterval;
            timer.Start();
        }
    }

    public void Stop()
    {
        if (timer.IsRunning)
            timer.Stop();
    }

    public void Clear()
    {
        startTime = DateTime.Now;
        UpdateValues(true);
    }

    private void Timer_Tick(object? sender, object e)
    {
        UpdateValues(false);
    }

    private void UpdateValues(bool reset)
    {
        if (reset)
            currentInterval = new TimeSpan();
        else
            currentInterval = DateTime.Now - startTime;
        DisplayInterval = string.Format("{0:D2}:{1:D2}", currentInterval.Minutes, currentInterval.Seconds);
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler? PropertyChanged;
    private void RaisePropertyChanged([CallerMemberName]string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

}
