using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp;

namespace DDDInheritance.CommonEntities
{
    public interface ICommonEntityManager<T, TRepository> 
    where T : class, IBaseEntity
    where TRepository : ICommonEntityRepository<T>
    {
        Task<T> CreateAsync(string code, string name, Status? status = null, Guid? linked = null);

        Task<T> CreateAsync(T baseEntity);

        Task<T> UpdateAsync(Guid id,
            string code, string name, Status? status = null, Guid? linked = null,
            [CanBeNull] string concurrencyStamp = null);
    }
}
