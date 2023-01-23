using DDDInheritance.CommonEntities;
using System;
using System.Threading.Tasks;

namespace DDDInheritance.Betas
{
    public interface IBetaManager : ICommonEntityManager<Beta, ICommonEntityRepository<Beta>>
    {
        Task SetStatus(Guid id, Status status);
    }
}
