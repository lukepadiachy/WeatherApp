using Newtonsoft.Json;
using WeatherApp.Model;
using WinRT;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
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

        private HttpClient _client;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            GetLatestTemp(_client);

        }
        public async void GetLatestTemp(object parameters)
        {
            //this will get info from the internet
            string response = await _client.GetStringAsync(new Uri("https://api.openweathermap.org/data/2.5/weather?lat=44.34&lon=10.99&appid=13f3c4e6aaae5782ec1fd60e26c43d65"));

            // converts this  
            OpenWeatherData latesttemp = JsonConvert.DeserializeObject<OpenWeatherData>(response);
            if (latesttemp != null)
            {
                LatestTemp = latesttemp.main.temp;
            }

        }


    }

}
