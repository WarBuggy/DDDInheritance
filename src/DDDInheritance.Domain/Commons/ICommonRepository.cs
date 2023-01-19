using DDDInheritance;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace DDDInheritance.Commons
{
    public interface ICommonRepository : IRepository<Common, Guid>
    {
        Task<List<Common>> GetListAsync(
            string filterText = null,
            string code = null,
            string name = null,
            Status? status = null,
            Guid? linked = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string code = null,
            string name = null,
            Status? status = null,
            Guid? linked = null,
            CancellationToken cancellationToken = default);
    }
}