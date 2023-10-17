using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Sayaratech.Data;

public class SayaratechEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public SayaratechEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the SayaratechDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SayaratechDbContext>()
            .Database
            .MigrateAsync();
    }
}
