using DDDInheritance.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DDDInheritance;

[DependsOn(
    typeof(DDDInheritanceEntityFrameworkCoreTestModule)
    )]
public class DDDInheritanceDomainTestModule : AbpModule
{

}
