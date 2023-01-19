using DDDInheritance.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDDInheritance.Commons;

namespace DDDInheritance.Web.Pages.Commons
{
    public class CreateModalModel : DDDInheritancePageModel
    {
        [BindProperty]
        public CommonCreateViewModel Common { get; set; }

        private readonly ICommonsAppService _commonsAppService;

        public CreateModalModel(ICommonsAppService commonsAppService)
        {
            _commonsAppService = commonsAppService;
        }

        public async Task OnGetAsync()
        {
            Common = new CommonCreateViewModel();

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            await _commonsAppService.CreateAsync(ObjectMapper.Map<CommonCreateViewModel, CommonCreateDto>(Common));
            return NoContent();
        }
    }

    public class CommonCreateViewModel : CommonCreateDto
    {
    }
}