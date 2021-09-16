using Domain.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Api.Http
{
    // This file is not part of clean code. Just a helper menthod to push some data at the starting of the project
    public class DataGenerator
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
            serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                if (context.Weathers.Any())
                    return;

                var rng = new Random();

                context.Weathers.AddRange(Enumerable.Range(1, 5).Select(index => new Weather
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToArray());
                context.SaveChanges();
            }
        }
    }
}
