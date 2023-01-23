using DDDInheritance.Alphas;
using DDDInheritance.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace DDDInheritance.Betas
{
    public class BetaManager : CommonEntityManager<Beta, IBetaRepository>, IBetaManager
    {
        public BetaManager(IBetaRepository repository) : base(repository)
        {
        }

        public async Task SetStatus(Guid id, Status status)
        {
            Beta beta = await _repository.GetAsync(id);
            beta.Status = status;
            await _repository.UpdateAsync(beta);
        }
    }
}
