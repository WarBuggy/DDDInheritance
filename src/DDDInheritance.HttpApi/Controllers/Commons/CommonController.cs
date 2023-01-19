using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using DDDInheritance.Commons;
using Volo.Abp.Content;
using DDDInheritance.Shared;

namespace DDDInheritance.Controllers.Commons
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Common")]
    [Route("api/app/commons")]

    public class CommonController : AbpController, ICommonsAppService
    {
        private readonly ICommonsAppService _commonsAppService;

        public CommonController(ICommonsAppService commonsAppService)
        {
            _commonsAppService = commonsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CommonDto>> GetListAsync(GetCommonsInput input)
        {
            return _commonsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CommonDto> GetAsync(Guid id)
        {
            return _commonsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CommonDto> CreateAsync(CommonCreateDto input)
        {
            return _commonsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CommonDto> UpdateAsync(Guid id, CommonUpdateDto input)
        {
            return _commonsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _commonsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CommonExcelDownloadDto input)
        {
            return _commonsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _commonsAppService.GetDownloadTokenAsync();
        }
    }
}