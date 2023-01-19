using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DDDInheritance.Web;

[Dependency(ReplaceServices = true)]
public class DDDInheritanceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DDDInheritance";
}
