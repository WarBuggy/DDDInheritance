using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace DDDInheritance.Web.Pages;

public class IndexModel : DDDInheritancePageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
