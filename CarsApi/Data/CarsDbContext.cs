using CarApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options)
        : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;


    }
}
