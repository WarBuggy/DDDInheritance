using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Content;
using Volo.Abp.Gdpr;
using Volo.Abp;

namespace DDDInheritance.CommonEntities
{

    [RemoteService]
    [Area("app")]
    [ControllerName("Common")]
    [Route("api/app/commons")]
    public class CommonControllers : AbpController, ICommonEntitiesAppService
    {
        protected readonly ICommonEntitiesAppService _appService;

        public CommonControllers(ICommonEntitiesAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CommonEntityDto>> GetListAsync(GetCommonEntitiesInput input)
        {
            return _appService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CommonEntityDto> GetAsync(Guid id)
        {
            return _appService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CommonEntityDto> CreateAsync(CommonEntityCreateDto input)
        {
            return _appService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CommonEntityDto> UpdateAsync(Guid id, CommonEntityUpdateDto input)
        {
            return _appService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _appService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CommonEntityExcelDownloadDto input)
        {
            return _appService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _appService.GetDownloadTokenAsync();
        }
    }
}
