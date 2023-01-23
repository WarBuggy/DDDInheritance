using DDDInheritance.CommonEntities;
using DDDInheritance.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Microsoft.AspNetCore.Authorization;
using DDDInheritance.Permissions;

namespace DDDInheritance.Alphas
{
    public class AlphasAppService : CommonEntitiesAppService<Alpha, IAlphaManager>, IAlphasAppService
    {
        private readonly IStringLocalizer<DDDInheritanceResource> _localizer;

        public AlphasAppService(IAlphaRepository repository,
            IAlphaManager manager,
            IDistributedCache<CommonEntityExcelDownloadTokenCacheItem, string> excelDownloadTokenCache,
            IStringLocalizer<DDDInheritanceResource> localizer)
            : base(repository, manager, DDDInheritancePermissions.Alphas.Default, excelDownloadTokenCache)
        {
            _localizer = localizer;
        }

        [Authorize(DDDInheritancePermissions.Alphas.Default)]
        public async Task<string> GetStatus(Guid id)
        {
            Status? status = await ((IAlphaRepository)_repository).GetStatus(id);
            string statusString = status == null ? "NULL" : status.ToString();
            return _localizer[$"EnumValue:DDDInheritance:Status:{statusString}"];
        }
    }
}
