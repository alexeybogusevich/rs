using Microsoft.EntityFrameworkCore;
using System;

namespace KNU.RS.DbManager.Connections
{
    public static class AzureSqlDbContextOptionsBuilder
    {
        public static DbContextOptions<AzureSqlDbContext> GetOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AzureSqlDbContext>();
            optionsBuilder.UseSqlServer(
                connectionString: Environment.GetEnvironmentVariable(connectionString, EnvironmentVariableTarget.Process));
            return optionsBuilder.Options;
        }
    }
}
