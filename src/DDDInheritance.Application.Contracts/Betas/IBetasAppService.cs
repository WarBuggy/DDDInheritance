using DDDInheritance.CommonEntities;
using System;
using System.Threading.Tasks;

namespace DDDInheritance.Betas
{
    public interface IBetasAppService : ICommonEntitiesAppService
    {
        Task SetStatus(Guid id, Status status);
    }
}
