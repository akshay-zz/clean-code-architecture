using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IWeatherRepository
    {
        public Task<IEnumerable<Weather>> GetWeatherReport();
    }
}
