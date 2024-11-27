using System.Globalization;

namespace Weather.Converters;

public class ActiveTabConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var target = (string)value;
        var tab = (string)parameter;

        switch(tab)
        {
            case "Home":
                return (target == "Home") ? "tab_home_on.png" : "tab_home.png";
            case "Favorites":
                return (target == "Favorites") ? "tab_favorites_on.png" : "tab_favorites.png";
            default:
                return "tab_home.png";
        }
    }


    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (string)value;
    }
}