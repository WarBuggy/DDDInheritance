using DDDInheritance.Alphas;
using DDDInheritance.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInheritance.Betas
{
    public class BetaManager : CommonEntityManager<Beta, IBetaRepository>, IBetaManager
    {
        public BetaManager(IBetaRepository repository) : base(repository)
        {
        }
    }
}
