namespace Weather.Views;

public partial class CurrentWidget
{
    public CurrentWidget()
    {
        InitializeComponent();
    }
}
public class MainPageViewModel
{
    public string CurrentDateWithDayOfWeek => DateTime.Now.ToString("dddd, MMMM dd, yyyy");
}
