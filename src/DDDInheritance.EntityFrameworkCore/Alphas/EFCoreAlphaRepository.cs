using DDDInheritance.CommonEntities;
using DDDInheritance.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace DDDInheritance.Alphas
{
    public class EFCoreAlphaRepository : EFCoreCommonEntityRepository<Alpha>, IAlphaRepository
    {
        public EFCoreAlphaRepository(IDbContextProvider<DDDInheritanceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Status?> GetStatus(Guid id)
        {
            return (await GetAsync(id)).Status;
        }
    }
}
