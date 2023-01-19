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
using DDDInheritance.Commons;

namespace DDDInheritance.Alphas
{
    public class EFCoreAlphaRepository : EFCoreCommonRepository<DDDInheritanceDbContext, Alpha>, IAlphaRepository
    {
        public EFCoreAlphaRepository(IDbContextProvider<DDDInheritanceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }   
    
    /*
        public class EfCoreAlphaRepository : EfCoreRepository<DDDInheritanceDbContext, Alpha, Guid>, IAlphaRepository, ICommonRepository
        {
            public EfCoreAlphaRepository(IDbContextProvider<DDDInheritanceDbContext> dbContextProvider)
                : base(dbContextProvider)
            {

            }

            public async Task<List<Alpha>> GetListAsync(
                string filterText = null,
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
                return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
            }

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

            protected virtual IQueryable<Alpha> ApplyFilter(
                IQueryable<Alpha> query,
                string filterText,
                string code = null,
                string name = null,
                Status? status = null,
                Guid? linked = null)
            {
                return query
                        .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.Contains(filterText) || e.Name.Contains(filterText))
                        .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.Contains(code))
                        .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                        .WhereIf(status.HasValue, e => e.Status == status)
                        .WhereIf(linked.HasValue, e => e.Linked == linked);
            }
        }
        */
    }