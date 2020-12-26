using Microsoft.EntityFrameworkCore;

namespace KNU.RS.DbManager.Connections
{
    public class AzureSqlDbContext : DbContext
    {


        public AzureSqlDbContext(DbContextOptions<AzureSqlDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
