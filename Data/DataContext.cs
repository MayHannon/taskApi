using Microsoft.EntityFrameworkCore;
using taskApi.Model;

namespace taskApi.Data

{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<FalgeEntity> Flage { get; set; }

    }
}