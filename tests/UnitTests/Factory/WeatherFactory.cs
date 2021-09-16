using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Factory
{
    public class WeatherFactory
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static IEnumerable<Weather> FakeWeather() {
            var rng = new Random();
            var data = new List<Weather>();

            data.AddRange(Enumerable.Range(1, 5).Select(index => new Weather
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }));

            return data;
        }
    }
}
