using Api.Http;
using Application.Request.Models;
using FluentAssertions;
using Mailer.IntegrationTests;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class WeatherForecastTest
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public WeatherForecastTest()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task WeatherForecastApi_Should_GiveWeatherStatus()
        {
            // Act
            var response = await _client.GetAsync("/api/WeatherForecast");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WeatherForecast[]>(content);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Count().Should().BeGreaterOrEqualTo(1);
        }
    }
}