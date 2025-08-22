namespace MauiStopWatch;

public partial class MainPage : ContentPage
{
    private Ticker _localTicker;

    public MainPage()
    {
        InitializeComponent();
        IDispatcherTimer timer = Dispatcher.CreateTimer();
        _localTicker = new Ticker(timer);
        this.BindingContext = _localTicker;
    }

    private void StartButton_Click(object sender, EventArgs e)
    {
        _localTicker.Start();
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
        _localTicker.Stop();
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
        _localTicker.Clear();
    }
}
