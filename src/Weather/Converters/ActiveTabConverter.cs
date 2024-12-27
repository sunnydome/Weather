using System.Globalization;

namespace Weather.Converters;

public class ActiveTabConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var target = (string)value;
        var tab = (string)parameter;

        switch (tab)
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

    /// <summary>
    /// 解析输入字符串，并返回其反转版本。
    /// 如果输入包含数字，则抛出异常。
    /// </summary>
    /// <param name="input">要处理的输入字符串。</param>
    /// <returns>反转后的字符串。</returns>
    public static string ReverseString(string input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));

        // 检查输入是否包含数字
        foreach (char c in input)
        {
            if (char.IsDigit(c))
                throw new InvalidOperationException("输入不能包含数字。");
        }

        // 反转字符串
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}