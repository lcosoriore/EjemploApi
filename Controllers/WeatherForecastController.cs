using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EjemploApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private static List<WeatherForecast> _forecasts = new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            if (_forecasts == null || !_forecasts.Any())
            {
                _forecasts= Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
           .ToList();
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("Se retorna el listado solicitado");
            return _forecasts;
        }

        [HttpPost]

        public IActionResult Post(WeatherForecast weatherForecast)
        {
            _forecasts.Add(weatherForecast);

            return Ok();
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            _forecasts.RemoveAt(index);

            return Ok();
        }
    }
}