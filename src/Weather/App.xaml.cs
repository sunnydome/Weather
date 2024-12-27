using System.Diagnostics;

namespace Weather;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

    }

    async void TapGestureRecognizer_Tapped(Object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"///settings");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"err: {ex.Message}");
        }
    }
}


