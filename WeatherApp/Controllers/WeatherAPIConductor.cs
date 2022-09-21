using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;


namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherAPIConductor : ControllerBase
    {
        [HttpGet]
        public async Task<Root> Index() {
            var httpClient = new HttpClient();
            string openWeatherKey = Environment.GetEnvironmentVariable("WEATHERAPP_KEY");
            Console.WriteLine(openWeatherKey);
            var forecast = httpClient.GetAsync("http://api.openweathermap.org/data/2.5/forecast?id=2615876&appid="+ openWeatherKey);
            var json = await forecast.Result.Content.ReadFromJsonAsync<Root>();
            return json;
        }
        [HttpGet("{id}")]
        public async Task<Root> Index(int id)
        {
            var httpClient = new HttpClient();
            string openWeatherKey = Environment.GetEnvironmentVariable("WEATHERAPP_KEY");
            Console.WriteLine(openWeatherKey);
            var forecast = httpClient.GetAsync("http://api.openweathermap.org/data/2.5/forecast?id=" + id + "&appid="+ openWeatherKey);
            var json = await forecast.Result.Content.ReadFromJsonAsync<Root>();
            return json;
        }
    }
}
