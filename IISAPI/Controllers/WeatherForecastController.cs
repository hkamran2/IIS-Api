using IISAPI.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private IWebHostEnvironment webHostEnvironment;
        private readonly IWeatherForecastRepository weatherForecastRepository;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment webHostEnvironment, IWeatherForecastRepository weatherForecastRepository)
        {
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            this.weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(int start=0, int end=5)
        {
            _logger.LogDebug("Running in env: " + webHostEnvironment.EnvironmentName);
            _logger.LogDebug("Fetching records for weather forecast");


            var rng = new Random();
            return weatherForecastRepository.GetForecasts(start, end)
            .ToArray();
        }
    }
}
