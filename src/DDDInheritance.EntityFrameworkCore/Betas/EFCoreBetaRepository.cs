using DDDInheritance.CommonEntities;
using DDDInheritance.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DDDInheritance.Betas
{
    public class EFCoreBetaRepository : EFCoreCommonEntityRepository<Beta>, IBetaRepository
    {
        public EFCoreBetaRepository(IDbContextProvider<DDDInheritanceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
