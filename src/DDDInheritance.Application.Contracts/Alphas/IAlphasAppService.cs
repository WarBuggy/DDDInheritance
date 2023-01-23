using DDDInheritance.CommonEntities;
using System.Threading.Tasks;
using System;

namespace DDDInheritance.Alphas
{
    public interface IAlphasAppService : ICommonEntitiesAppService
    {
        Task<string> GetStatus(Guid id);
    }
}
