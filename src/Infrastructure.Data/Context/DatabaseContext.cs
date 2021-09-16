using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public virtual DbSet<Weather> Weathers { get; set; }
    }
}
