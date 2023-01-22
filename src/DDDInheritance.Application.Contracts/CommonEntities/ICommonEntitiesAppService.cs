using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.Gdpr;

namespace DDDInheritance.CommonEntities
{
    public interface ICommonEntitiesAppService : IApplicationService
    {
        Task<PagedResultDto<CommonEntityDto>> GetListAsync(GetCommonEntitiesInput input);

        Task<CommonEntityDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CommonEntityDto> CreateAsync(CommonEntityCreateDto input);

        Task<CommonEntityDto> UpdateAsync(Guid id, CommonEntityUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CommonEntityExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}
