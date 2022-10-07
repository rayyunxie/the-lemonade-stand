using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using tls.api.Repositories;

namespace tls.api.DesignTime
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environmentName}.json", true)
                    .Build();

            var appOptions = new AppOptions();
            configuration.Bind(Constants.ConfigSection, appOptions);

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(appOptions.SqlConnection!)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            return new RepositoryContext(builder.Options);
        }
    }
}
