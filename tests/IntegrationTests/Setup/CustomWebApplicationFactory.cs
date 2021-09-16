using Domain.Models;
using Infrastructure.Data.Context;
using IntegrationTests.Setup;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Mailer.IntegrationTests
{
    //Reference: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0

    public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
    {
        public ServiceProvider TestServiceProvider { get; protected set; }

        private readonly bool _addAuthentication;
        public CustomWebApplicationFactory(bool addAuthentication = true) : base()
        {
            _addAuthentication = addAuthentication;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<DatabaseContext>));

                services.Remove(descriptor);

                services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });


                // If you need to by pass authentication
                if (_addAuthentication)
                {
                    services.AddAuthentication("Test")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
                }

                var sp = services.BuildServiceProvider();
                TestServiceProvider = sp;

                // Configure Database
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<DatabaseContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    // Dump data for testing
                    try
                    {
                        var rng = new Random();

                        db.Weathers.AddRange(Enumerable.Range(1, 5).Select(index => new Weather
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = rng.Next(-20, 55),
                            Summary = Summaries[rng.Next(Summaries.Length)]
                        }).ToArray());
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                            "database with test messages. Error: {Message}", ex.Message);
                    }
                }
            });
        }


        // Remove in real project used to create testing data
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}