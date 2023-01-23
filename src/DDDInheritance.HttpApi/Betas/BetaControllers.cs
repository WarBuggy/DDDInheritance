using DDDInheritance.Alphas;
using DDDInheritance.CommonEntities;
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
    public class BetaControllers : CommonControllers, IBetasAppService
    {
        public BetaControllers(IBetasAppService appService) : base(appService)
        {
        }
    }
}
