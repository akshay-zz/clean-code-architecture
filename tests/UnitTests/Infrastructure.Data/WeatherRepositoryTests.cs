using FluentAssertions;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using UnitTests.Factory;
using UnitTests.Setup;

namespace UnitTests.Infrastructure.Data
{
    public class WeatherRepositoryTests
    {
        [Test]
        public async Task GetWeatherReport()
        {
            //Arrange
            var data = WeatherFactory.FakeWeather();
            var mockSet = TestDbFactory.CreateDbSetMock(data.AsQueryable());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(x => x.Weathers).Returns(mockSet.Object);

            var repo = new WeatherRepository(mockContext.Object);

            //Act
            var results = await repo.GetWeatherReport();

            //Assert
            results.Count().Should().Be(5);
        }
    }
}
