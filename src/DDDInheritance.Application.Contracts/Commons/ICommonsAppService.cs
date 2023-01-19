using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using DDDInheritance.Shared;

namespace DDDInheritance.Commons
{
    public interface ICommonsAppService : IApplicationService
    {
        Task<PagedResultDto<CommonDto>> GetListAsync(GetCommonsInput input);

        Task<CommonDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CommonDto> CreateAsync(CommonCreateDto input);

        Task<CommonDto> UpdateAsync(Guid id, CommonUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CommonExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}