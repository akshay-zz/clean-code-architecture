using Application.Request.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWeatherForecastService
    {
        public Task<IEnumerable<WeatherForecast>> GetWeatherForecast();
    }
}
