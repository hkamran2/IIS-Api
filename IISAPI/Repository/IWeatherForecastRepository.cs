using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISAPI.Repository
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> GetForecasts(int start = 0, int end = 5);
    }

    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public IEnumerable<WeatherForecast> GetForecasts(int start = 1, int end = 5)
        {
            var rng = new Random();
            return Enumerable.Range(start, end).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
    }
}
