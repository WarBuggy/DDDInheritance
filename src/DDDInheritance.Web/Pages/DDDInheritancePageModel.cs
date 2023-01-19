using DDDInheritance.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DDDInheritance.Web.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class DDDInheritancePageModel : AbpPageModel
{
    protected DDDInheritancePageModel()
    {
        LocalizationResourceType = typeof(DDDInheritanceResource);
    }
}
