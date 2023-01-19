using DDDInheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using DDDInheritance.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;

namespace DDDInheritance.Commons
{
    public class EFCoreCommonRepository<TDbContext, TEntity> : EfCoreRepository<DDDInheritanceDbContext, TEntity, Guid>, ICommonRepository<TEntity>
        where TEntity : Common
    {
        public EFCoreCommonRepository(IDbContextProvider<DDDInheritanceDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        //public async Task<List<Common>> GetListAsync(
        //    string filterText = null,
        //    string code = null,
        //    string name = null,
        //    Status? status = null,
        //    Guid? linked = null,
        //    string sorting = null,
        //    int maxResultCount = int.MaxValue,
        //    int skipCount = 0,
        //    CancellationToken cancellationToken = default)
        //{
        //    var query = ApplyFilter((await GetQueryableAsync()), filterText, code, name, status, linked);
        //    query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CommonConsts.GetDefaultSorting(false) : sorting);
        //    return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        //}

        public async Task<long> GetCountAsync(
            string filterText = null,
            string code = null,
            string name = null,
            Status? status = null,
            Guid? linked = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, code, name, status, linked);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<IEntity> ApplyFilter<IEntity>(
            IQueryable<IEntity> query,
            string filterText,
            string code = null,
            string name = null,
            Status? status = null,
            Guid? linked = null) where IEntity : ICommon
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.Contains(filterText) || e.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.Contains(code))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(status.HasValue, e => e.Status == status)
                    .WhereIf(linked.HasValue, e => e.Linked == linked);
        }

        public async Task<List<IEntity>> GetListAsync(
            string filterText,
            string code = null,
            string name = null,
            Status? status = null,
            Guid? linked = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, name, status, linked);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CommonConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync<IEntity>(cancellationToken);
        }
    }
}

/*
 * 

    public async Task<IQueryable<TEntity>> GetQueryableWithRelatedDataAsync()
    {
        return await DbSet.Include(x => x.Code).Include(x => x.Name).ToListAsync();
    }

    public async Task<IQueryable<TEntity>> GetQueryableAsNoTrackingAsync()
    {
        return DbSet.AsNoTracking();
    }

    public async Task<IQueryable<CommonDto>> GetQueryableWithSpecificPropertiesAsync()
    {
        return DbSet.Select(x => new CommonDto { Id = x.Id, Code = x.Code, Name = x.Name });
    }

*
*
*/