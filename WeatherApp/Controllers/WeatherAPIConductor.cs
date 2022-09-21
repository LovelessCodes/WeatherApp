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
            var forecast = httpClient.GetAsync("http://api.openweathermap.org/data/2.5/forecast?id=2615876&appid=af5bcb9ea1e67227ac9c7ae49d00eab1");
            var json = await forecast.Result.Content.ReadFromJsonAsync<Root>();
            return json;
        }
        [HttpGet("{id}")]
        public async Task<Root> Index(int id)
        {
            var httpClient = new HttpClient();
            var forecast = httpClient.GetAsync("http://api.openweathermap.org/data/2.5/forecast?id=" + id + "&appid=af5bcb9ea1e67227ac9c7ae49d00eab1");
            var json = await forecast.Result.Content.ReadFromJsonAsync<Root>();
            return json;
        }
    }
}
