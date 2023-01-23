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
    public class AlphasAppService : CommonEntitiesAppService<Alpha, IAlphaManager>, IAlphasAppService
    {
        public AlphasAppService(IAlphaRepository repository,
            IAlphaManager manager,
            IDistributedCache<CommonEntityExcelDownloadTokenCacheItem, string> excelDownloadTokenCache) 
            :base(repository, manager, excelDownloadTokenCache)
        {
        }
    }
}
