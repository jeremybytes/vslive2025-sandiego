namespace MauiStopWatch;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        //return new Window(new AppShell());
        var window = new Window(new MainPage());
        window.Height = 200;
        window.Width = 400;
        return window;
    }
}