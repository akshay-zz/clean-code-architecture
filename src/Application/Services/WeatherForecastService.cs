using Application.Interfaces;
using Application.Request.Models;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherForecastService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast()
        {
            var reports = await _weatherRepository.GetWeatherReport();

            return reports.Select(x => new WeatherForecast() { 
                Date = x.Date, Summary = x.Summary, TemperatureC = x.TemperatureC });
        }
    }
}
