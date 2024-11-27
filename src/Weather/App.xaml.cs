using System.Diagnostics;
using Weather.Pages;

namespace Weather;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

    }

    async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
    {
        try { 
            await Shell.Current.GoToAsync($"///settings");
        }catch (Exception ex) {
            Debug.WriteLine($"err: {ex.Message}");
        }
    }
}


