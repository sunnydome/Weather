using System.ComponentModel;
using System.Runtime.CompilerServices;
using Weather.Models;

namespace Weather.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    public List<Forecast> Week { get; set; }

    public List<Forecast> Hours { get; set; }

    public Command QuitCommand { get; set; } = new Command(() =>
    {
        Application.Current.Quit();
    });

    public Command<string> ChangeLocationCommand { get; set; } = new Command<string>((location) =>
    {
        // change primary location
    });



    public HomeViewModel()
    {
        InitData();
    }

    private void InitData()
    {
        Week = new List<Forecast>
            {
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(-1),
                    Day = new Day{ Phrase = "fluent_weather_sunny_high_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 22 }, Maximum = new Maximum { Unit = "C", Value = 27 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(1),
                    Day = new Day{ Phrase = "fluent_weather_sunny_high_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 22 }, Maximum = new Maximum { Unit = "C", Value = 27 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(2),
                    Day = new Day{ Phrase = "fluent_weather_partly_cloudy" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 21 }, Maximum = new Maximum { Unit = "C", Value = 28 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(3),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 22 }, Maximum = new Maximum { Unit = "C", Value = 27 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(4),
                    Day = new Day{ Phrase = "fluent_weather_thunderstorm_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 20 }, Maximum = new Maximum { Unit = "C", Value = 28 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(5),
                    Day = new Day{ Phrase = "fluent_weather_thunderstorm_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 19 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(6),
                    Day = new Day{ Phrase = "fluent_weather_partly_cloudy" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 19 }, Maximum = new Maximum { Unit = "C", Value = 27 } },
                }
            };

        Hours = new List<Forecast>
            {
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(1),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 21 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(2),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 21 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                }
                ,
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(3),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 21 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                }
                ,
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(4),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C ", Value = 21 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                }
                ,
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(5),
                    Day = new Day{ Phrase = "fluent_weather_cloudy_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 22 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(6),
                    Day = new Day{ Phrase = "fluent_weather_cloudy_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 23 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(7),
                    Day = new Day{ Phrase = "fluent_weather_cloudy_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 24 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(8),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 23 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(9),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 24 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(10),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 25 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(11),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 24 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(12),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 24 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(13),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 24 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(14),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "C", Value = 24 }, Maximum = new Maximum { Unit = "C", Value = 26 } },
                }
            };
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }

}
