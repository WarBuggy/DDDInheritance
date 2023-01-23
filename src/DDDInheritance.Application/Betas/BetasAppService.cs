using DDDInheritance.CommonEntities;
using DDDInheritance.Permissions;
using System;
using System.Threading.Tasks;
using Volo.Abp.Caching;

namespace DDDInheritance.Betas
{
    public class BetasAppService : CommonEntitiesAppService<Beta, IBetaManager>, IBetasAppService
    {
        public BetasAppService(IBetaRepository repository,
            IBetaManager manager,
            IDistributedCache<CommonEntityExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
            : base(repository, manager, DDDInheritancePermissions.Betas.Default, excelDownloadTokenCache)
        {
        }

        public async Task SetStatus(Guid id, Status status)
        {
            await ((IBetaManager)_manager).SetStatus(id, status);
        }
    }
}
