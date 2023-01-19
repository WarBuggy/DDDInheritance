using DDDInheritance.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DDDInheritance.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class DDDInheritanceController : AbpControllerBase
{
    protected DDDInheritanceController()
    {
        LocalizationResource = typeof(DDDInheritanceResource);
    }
}
