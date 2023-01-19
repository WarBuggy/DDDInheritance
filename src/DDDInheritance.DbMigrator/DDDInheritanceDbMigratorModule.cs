using DDDInheritance.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DDDInheritance.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DDDInheritanceEntityFrameworkCoreModule),
    typeof(DDDInheritanceApplicationContractsModule)
)]
public class DDDInheritanceDbMigratorModule : AbpModule
{

}
