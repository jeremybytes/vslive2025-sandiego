using System.Windows;

namespace WPFStopWatch;

public partial class MainWindow : Window
{
    private Ticker _localTicker;

    public MainWindow()
    {
        InitializeComponent();
        _localTicker = (Ticker)FindResource("LocalTicker");
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

    private void Window_Deactivated(object sender, EventArgs e)
    {
        Opacity = 0.5;
        Height = 90;
    }

    private void Window_Activated(object sender, EventArgs e)
    {
        Opacity = 1.0;
        Height = 150;
    }

    private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void CloseButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        Close();
    }
}