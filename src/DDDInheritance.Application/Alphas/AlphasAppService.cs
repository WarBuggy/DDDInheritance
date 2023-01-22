using DDDInheritance.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace DDDInheritance.Alphas
{
    public class AlphasAppService : CommonEntitiesAppService<Alpha, 
        ICommonEntityManager<Alpha, ICommonEntityRepository<Alpha>>>, IAlphasAppService
    {
        public AlphasAppService(ICommonEntityRepository<Alpha> repository,
            ICommonEntityManager<Alpha, ICommonEntityRepository<Alpha>> manager,
            IDistributedCache<CommonEntityExcelDownloadTokenCacheItem, string> excelDownloadTokenCache) 
            :base(repository, manager, excelDownloadTokenCache)
        {
        }
    }
}
