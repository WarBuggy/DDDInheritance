using DDDInheritance.CommonEntities;
using System;
using System.Threading.Tasks;

namespace DDDInheritance.Alphas
{
    public interface IAlphaRepository : ICommonEntityRepository<Alpha>
    {
        Task<Status?> GetStatus(Guid id);
    }
}
