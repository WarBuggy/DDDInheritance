using DDDInheritance.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace DDDInheritance.Alphas
{
    public class AlphasAppService : CommonsAppService, IAlphasAppService
    {
        //private readonly IAlphaRepository _alphaRepository;
        //private readonly CommonManager _commonManager;
        public AlphasAppService(ICommonRepository<Alpha> commonRepository, 
            CommonManager commonManager, 
            IDistributedCache<CommonExcelDownloadTokenCacheItem, string> excelDownloadTokenCache) 
            : base(commonRepository, commonManager, excelDownloadTokenCache)
        {
        }
    }
}