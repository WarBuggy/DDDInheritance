using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using DDDInheritance.Permissions;
using DDDInheritance.Commons;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using DDDInheritance.Shared;
using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectMapping;

namespace DDDInheritance.Commons
{
    [RemoteService(IsEnabled = false)]
    [Authorize(DDDInheritancePermissions.Commons.Default)]
    public class CommonsAppService : ApplicationService, ICommonsAppService
    {
        private readonly IDistributedCache<CommonExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICommonRepository<Common> _commonRepository;
        private readonly CommonManager _commonManager;

        public CommonsAppService(ICommonRepository<Common> commonRepository, CommonManager commonManager, IDistributedCache<CommonExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _commonRepository = commonRepository;
            _commonManager = commonManager;
        }

        public virtual async Task<PagedResultDto<CommonDto>> GetListAsync(GetCommonsInput input)
        {
            var totalCount = await _commonRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Status, input.Linked);
            var items = await _commonRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Status, input.Linked, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CommonDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Common>, List<CommonDto>>(items.Cast<Common>().ToList())
            };
        }

        public virtual async Task<CommonDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Common, CommonDto>(await _commonRepository.GetAsync(id));
        }

        [Authorize(DDDInheritancePermissions.Commons.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _commonRepository.DeleteAsync(id);
        }

        [Authorize(DDDInheritancePermissions.Commons.Create)]
        public virtual async Task<CommonDto> CreateAsync(CommonCreateDto input)
        {

            var common = await _commonManager.CreateAsync(
            input.Code, input.Name, input.Status, input.Linked
            );

            return ObjectMapper.Map<Common, CommonDto>(common);
        }

        [Authorize(DDDInheritancePermissions.Commons.Edit)]
        public virtual async Task<CommonDto> UpdateAsync(Guid id, CommonUpdateDto input)
        {

            var common = await _commonManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Status, input.Linked, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Common, CommonDto>(common);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CommonExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _commonRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Status, input.Linked);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Common>, List<CommonExcelDto>>(items.Cast<Common>().ToList()));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Commons.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CommonExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}