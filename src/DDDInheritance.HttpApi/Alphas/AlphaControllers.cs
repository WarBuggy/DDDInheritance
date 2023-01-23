using DDDInheritance.CommonEntities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;

namespace DDDInheritance.Alphas
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Alpha")]
    [Route("api/app/alphas")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class AlphaControllers : CommonControllers, IAlphasAppService
    {
        public AlphaControllers(IAlphasAppService appService) : base(appService) 
        {
        }

        [HttpGet]
        [Route("status/{id}")]
        public Task<string> GetStatus(Guid id)
        {
            return ((IAlphasAppService)_appService).GetStatus(id);
        }
    }
}