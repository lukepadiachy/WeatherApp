using Newtonsoft.Json;
using WeatherApp.Model;

namespace WeatherApp.Pages;

public partial class WeatherInfoPage : ContentPage
{
    
    public WeatherInfoPage()
	{
		InitializeComponent();
        
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = await GetWeatherData();
    }

    private async Task<OpenWeatherData> GetWeatherData() 
    { 
        var details =await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        if (details != PermissionStatus.Granted)
        {
            details = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }
        var location = await Geolocation.GetLocationAsync();
        
        var lat = location.Latitude;
        var lon = location.Longitude;

        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("Accept", "application/json");

        string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid=13f3c4e6aaae5782ec1fd60e26c43d65";

        var response = await client.GetStringAsync(url);

        var weatherData = JsonConvert.DeserializeObject<OpenWeatherData>(response);

        return weatherData;

    }
} 