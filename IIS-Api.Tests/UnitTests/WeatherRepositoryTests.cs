using IISAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IIS_Api.Tests.UnitTests
{
    public class WeatherRepositoryTests
    {
        [Fact]
        public void GetForecasts_SpecifyPagination_Returns7Records()
        {
            var weather = new WeatherForecastRepository();
            var result = weather.GetForecasts(0, 7);
            Assert.Equal(7, result.Count());
        }
    }
}
