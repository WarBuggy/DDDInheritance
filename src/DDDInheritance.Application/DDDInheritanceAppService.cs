using DDDInheritance.Localization;
using Volo.Abp.Application.Services;

namespace DDDInheritance;

/* Inherit your application services from this class.
 */
public abstract class DDDInheritanceAppService : ApplicationService
{
    protected DDDInheritanceAppService()
    {
        LocalizationResource = typeof(DDDInheritanceResource);
    }
}
