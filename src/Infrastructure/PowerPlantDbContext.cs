using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PowerPlantDbContext: DbContext
    {
        public PowerPlantDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<DailyTemperature> DailyTemperature { get; set; }

    }
}
