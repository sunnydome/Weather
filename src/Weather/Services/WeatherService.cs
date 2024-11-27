using System.Net.Http.Json;

namespace WeatherClient;

public class WeatherService : IWeatherService
{
    static List<Location> locations = new()
    {
        //示例数据
        new Location { Name = "Redmond", Coordinate = new Coordinate(32.0615, 118.7915), Icon = "fluent_weather_cloudy_20_filled.png", WeatherStation = "中国", Value = "16°" }
    };

    private readonly HttpClient httpClient;

    public WeatherService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Task<IEnumerable<Location>> GetLocations(string query)
        => Task.FromResult(locations.Where(l => l.Name.Contains(query)));

    public Task<WeatherResponse> GetWeather(Coordinate location)
        => httpClient.GetFromJsonAsync<WeatherResponse>($"/weather/{location}");
}
