using Newtonsoft.Json;
using WeatherApp.Model;

namespace WeatherApp.Pages;

public partial class WeatherInfoPage : ContentPage
{
    private double _latestTemp;
    public double LatestTemp
    {
        get { return _latestTemp; }
        set
        {
            _latestTemp = value;
            OnPropertyChanged();
        }
    }

    private int _latestHumid;
    public int LatestHumid
    {
        get { return _latestHumid; }
        set
        {
            _latestHumid = value;
            OnPropertyChanged();
        }
    }
    
    private double _getfeelsLike;
    
    public double GetFeelsLike
    {
        get { return _getfeelsLike; }
        set
        {
            _getfeelsLike = value;
            OnPropertyChanged();
        }
    }


    private HttpClient _client;
    public WeatherInfoPage()
	{
		InitializeComponent();
        BindingContext = this;
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("Accept", "application/json");
        GetLatestTemp(_client);
        GetLatestHumid(_client);
        GetLatestFeelLike(_client);
    }

    public async void GetLatestTemp(object parameters)
    {
        //this will get info from the internet
        string response = await _client.GetStringAsync(new Uri("https://api.openweathermap.org/data/2.5/weather?lat=44.34&lon=10.99&appid=13f3c4e6aaae5782ec1fd60e26c43d65&units=metric"));

        // converts this  
        OpenWeatherData latesttemp = JsonConvert.DeserializeObject<OpenWeatherData>(response);
        if (latesttemp != null)
        {
            LatestTemp = latesttemp.main.temp;
        }

    }
    public async void GetLatestHumid(object parameters)
    {
        //this will get info from the internet
        string response = await _client.GetStringAsync(new Uri("https://api.openweathermap.org/data/2.5/weather?lat=44.34&lon=10.99&appid=13f3c4e6aaae5782ec1fd60e26c43d65&units=metric"));

        // converts this  
        OpenWeatherData latestHumid = JsonConvert.DeserializeObject<OpenWeatherData>(response);
        if (latestHumid != null)
        {
            LatestHumid = latestHumid.main.humidity;
        }

    }

    public async void GetLatestFeelLike(object parameters)
    {
        //this will get info from the internet
        string response = await _client.GetStringAsync(new Uri("https://api.openweathermap.org/data/2.5/weather?lat=44.34&lon=10.99&appid=13f3c4e6aaae5782ec1fd60e26c43d65&units=metric"));

        // converts this  
        OpenWeatherData getfeelsLike = JsonConvert.DeserializeObject<OpenWeatherData>(response);
        if (getfeelsLike != null)
        {
            GetFeelsLike = getfeelsLike.main.feels_like;
        }

    }

} 