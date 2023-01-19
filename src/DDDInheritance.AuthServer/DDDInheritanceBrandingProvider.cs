using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DDDInheritance;

[Dependency(ReplaceServices = true)]
public class DDDInheritanceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DDDInheritance";
}
