using DDDInheritance.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Volo.Abp.Content;
using Volo.Abp.Gdpr;
using Volo.Abp;
using MiniExcelLibs;

namespace DDDInheritance.CommonEntities
{
    [RemoteService(IsEnabled = false)]
    //[Authorize(DDDInheritancePermissions.Commons.Default)]
    public class CommonEntitiesAppService<T, TManager> : ApplicationService, ICommonEntitiesAppService
        where T : class, IBaseEntity
        where TManager : class, ICommonEntityManager<T, ICommonEntityRepository<T>>
    {
        protected readonly IDistributedCache<CommonEntityExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected readonly ICommonEntityRepository<T> _repository;
        protected readonly ICommonEntityManager<T, ICommonEntityRepository<T>> _manager;
        protected readonly string _permissionDefault;

        public CommonEntitiesAppService(ICommonEntityRepository<T> repository,
            ICommonEntityManager<T, ICommonEntityRepository<T>> manager, 
            string permissionDefault,
            IDistributedCache<CommonEntityExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _repository = repository;
            _manager = manager;
            _permissionDefault = permissionDefault;
        }

        public virtual async Task<PagedResultDto<CommonEntityDto>> GetListAsync(GetCommonEntitiesInput input)
        {
            await CheckPermission();

            var totalCount = await _repository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Status, input.Linked);
            var items = await _repository.GetListAsync(input.FilterText, input.Code, input.Name, input.Status, input.Linked, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CommonEntityDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<T>, List<CommonEntityDto>>(items.Cast<T>().ToList())
            };
        }

        public virtual async Task<CommonEntityDto> GetAsync(Guid id)
        {
            await CheckPermission();

            return ObjectMapper.Map<T, CommonEntityDto>(await _repository.GetAsync(id));
        }

        //[Authorize(DDDInheritancePermissions.Commons.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await CheckPermission("Delete");

            await _repository.DeleteAsync(id);
        }

        //[Authorize(DDDInheritancePermissions.Commons.Create)]
        public virtual async Task<CommonEntityDto> CreateAsync(CommonEntityCreateDto input)
        {
            await CheckPermission("Create");

            var common = await _manager.CreateAsync(
            input.Code, input.Name, input.Status, input.Linked
            );

            return ObjectMapper.Map<T, CommonEntityDto>(common);
        }

        //[Authorize(DDDInheritancePermissions.Commons.Edit)]
        public virtual async Task<CommonEntityDto> UpdateAsync(Guid id, CommonEntityUpdateDto input)
        {
            await CheckPermission("Edit");

            var common = await _manager.UpdateAsync(
            id,
            input.Code, input.Name, input.Status, input.Linked, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<T, CommonEntityDto>(common);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CommonEntityExcelDownloadDto input)
        {
            await CheckPermission();

            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _repository.GetListAsync(input.FilterText, input.Code, input.Name, input.Status, input.Linked);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<T>, List<CommonEntityExcelDto>>(items.Cast<T>().ToList()));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Commons.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            await CheckPermission();

            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CommonEntityExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }

        private async Task CheckPermission(string operationPermission = "")
        {
            string lastString = operationPermission == "" ? "" : $".{operationPermission}";
            await AuthorizationService.CheckAsync($"{_permissionDefault}{lastString}");
        }
    }
}
