using DDDInheritance.CommonEntities;
using DDDInheritance.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;

namespace DDDInheritance.Betas
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Beta")]
    [Route("api/app/betas")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class BetaControllers : CommonControllers, IBetasAppService
    {
        public BetaControllers(IBetasAppService appService) : base(appService)
        {
        }

        [HttpPut]
        [Authorize(DDDInheritancePermissions.Betas.Edit)]
        [Route("set-status/{id}")]
        public Task SetStatus(Guid id, Status status)
        {
            return ((IBetasAppService)_appService).SetStatus(id, status);
        }
    }
}
