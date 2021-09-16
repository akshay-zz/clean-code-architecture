using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly DatabaseContext _context;

        public WeatherRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Weather>> GetWeatherReport()
        {
            return await _context.Weathers.ToListAsync();
        }
    }
}
