using System.Threading.Tasks;

namespace DDDInheritance.Data;

public interface IDDDInheritanceDbSchemaMigrator
{
    Task MigrateAsync();
}
