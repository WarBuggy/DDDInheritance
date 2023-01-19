using DDDInheritance;
using DDDInheritance.Commons;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace DDDInheritance.Alphas
{
    public interface IAlphaRepository : ICommonRepository<Alpha>
    {
        // You can add additional methods specific to the Alpha entity here.
    }
}