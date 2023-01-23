using DDDInheritance.CommonEntities;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace DDDInheritance.Alphas
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Alpha")]
    [Route("api/app/alphas")]
    public class AlphaControllers : CommonControllers, IAlphasAppService
    {
        public AlphaControllers(IAlphasAppService appService) : base(appService) 
        {
        }
    }
}