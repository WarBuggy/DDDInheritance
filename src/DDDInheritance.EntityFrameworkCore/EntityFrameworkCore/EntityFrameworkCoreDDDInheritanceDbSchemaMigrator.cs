using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DDDInheritance.Data;
using Volo.Abp.DependencyInjection;

namespace DDDInheritance.EntityFrameworkCore;

public class EntityFrameworkCoreDDDInheritanceDbSchemaMigrator
    : IDDDInheritanceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreDDDInheritanceDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the DDDInheritanceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DDDInheritanceDbContext>()
            .Database
            .MigrateAsync();
    }
}
