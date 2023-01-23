using DDDInheritance.CommonEntities;
using Volo.Abp.Caching;

namespace DDDInheritance.Betas
{
    public class BetasAppService : CommonEntitiesAppService<Beta, IBetaManager>, IBetasAppService
    {
        public BetasAppService(IBetaRepository repository,
            IBetaManager manager,
            IDistributedCache<CommonEntityExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
            : base(repository, manager, excelDownloadTokenCache)
        {
        }
    }
}
