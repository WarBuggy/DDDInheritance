using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DDDInheritance.Data;

/* This is used if database provider does't define
 * IDDDInheritanceDbSchemaMigrator implementation.
 */
public class NullDDDInheritanceDbSchemaMigrator : IDDDInheritanceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
