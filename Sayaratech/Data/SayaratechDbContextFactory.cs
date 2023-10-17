using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sayaratech.Data;

public class SayaratechDbContextFactory : IDesignTimeDbContextFactory<SayaratechDbContext>
{
    public SayaratechDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SayaratechDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new SayaratechDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
