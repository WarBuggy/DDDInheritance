using DDDInheritance.CommonEntities;
using DDDInheritance.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Caching;

namespace DDDInheritance.Alphas
{
    public class AlphasAppService : CommonEntitiesAppService<Alpha, IAlphaManager>, IAlphasAppService
    {
        private readonly IStringLocalizer<DDDInheritanceResource> _localizer;

        public AlphasAppService(IAlphaRepository repository,
            IAlphaManager manager,
            IDistributedCache<CommonEntityExcelDownloadTokenCacheItem, string> excelDownloadTokenCache,
            IStringLocalizer<DDDInheritanceResource> localizer)
            : base(repository, manager, excelDownloadTokenCache)
        {
            _localizer = localizer;
        }

        public async Task<string> GetStatus(Guid id)
        {
            Status? status = await ((IAlphaRepository)_repository).GetStatus(id);
            string statusString = status == null ? "NULL" : status.ToString();
            return _localizer[$"DDDInheritance:EnumValue:Status:{statusString}"];
        }
    }
}
