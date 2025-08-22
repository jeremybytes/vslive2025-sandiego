using Microsoft.UI.Xaml;
using Windows.Graphics;

namespace WinUIStopWatch;

public sealed partial class MainWindow : Window
{
    private Ticker _localTicker;

    public MainWindow()
    {
        InitializeComponent();
        AppWindow.Resize(new SizeInt32(400, 250));
        _localTicker = (Ticker)LayoutGrid.Resources["LocalTicker"];
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        _localTicker.Start();
    }

    private void StopButton_Click(object sender, RoutedEventArgs e)
    {
        _localTicker.Stop();
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        _localTicker.Clear();
    }
}
