using DDDInheritance.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using DDDInheritance.Commons;

namespace DDDInheritance.Web.Pages.Commons
{
    public class EditModalModel : DDDInheritancePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CommonUpdateViewModel Common { get; set; }

        private readonly ICommonsAppService _commonsAppService;

        public EditModalModel(ICommonsAppService commonsAppService)
        {
            _commonsAppService = commonsAppService;
        }

        public async Task OnGetAsync()
        {
            var common = await _commonsAppService.GetAsync(Id);
            Common = ObjectMapper.Map<CommonDto, CommonUpdateViewModel>(common);

        }

        public async Task<NoContentResult> OnPostAsync()
        {

            await _commonsAppService.UpdateAsync(Id, ObjectMapper.Map<CommonUpdateViewModel, CommonUpdateDto>(Common));
            return NoContent();
        }
    }

    public class CommonUpdateViewModel : CommonUpdateDto
    {
    }
}