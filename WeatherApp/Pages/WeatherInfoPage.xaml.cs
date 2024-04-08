using Newtonsoft.Json;
using WeatherApp.Model;

namespace WeatherApp.Pages;

public partial class WeatherInfoPage : ContentPage
{
    private HttpClient _client;
    public WeatherInfoPage()
	{
		InitializeComponent();
        
    }
} 