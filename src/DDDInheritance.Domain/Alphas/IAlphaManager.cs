using DDDInheritance.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInheritance.Alphas
{
    public interface IAlphaManager : ICommonEntityManager<Alpha, IAlphaRepository>
    {
    }
}
