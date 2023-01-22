using DDDInheritance.CommonEntities;

namespace DDDInheritance.Alphas
{
    public class AlphaManager : CommonEntityManager<Alpha, IAlphaRepository>
    {
        public AlphaManager(IAlphaRepository repository) : base(repository)
        {
        }
    }
}
