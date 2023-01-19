using DDDInheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using DDDInheritance.Commons;
using DDDInheritance.Shared;

namespace DDDInheritance.Web.Pages.Commons
{
    public class IndexModel : AbpPageModel
    {
        public string CodeFilter { get; set; }
        public string NameFilter { get; set; }
        public Status? StatusFilter { get; set; }
        public string LinkedFilter { get; set; }

        private readonly ICommonsAppService _commonsAppService;

        public IndexModel(ICommonsAppService commonsAppService)
        {
            _commonsAppService = commonsAppService;
        }

        public async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}