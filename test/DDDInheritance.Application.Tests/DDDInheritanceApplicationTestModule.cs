using Volo.Abp.Modularity;

namespace DDDInheritance;

[DependsOn(
    typeof(DDDInheritanceApplicationModule),
    typeof(DDDInheritanceDomainTestModule)
    )]
public class DDDInheritanceApplicationTestModule : AbpModule
{

}
