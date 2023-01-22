using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;
using Volo.Abp;
using DDDInheritance.Alphas;
using Volo.Abp.Domain.Entities;

namespace DDDInheritance.CommonEntities
{
    public class CommonEntityManager<TCommonEntity, TRepository> : DomainService
       where TCommonEntity : class, IBaseEntity, new()
       where TRepository : class, ICommonEntityRepository<TCommonEntity>
    {
        private readonly TRepository _repository;

        public CommonEntityManager(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<TCommonEntity> CreateAsync(string code, string name, 
            Status? status = null, Guid? linked = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), CommonEntityConsts.CodeMaxLength, CommonEntityConsts.CodeMinLength);
            Check.Length(name, nameof(name), CommonEntityConsts.NameMaxLength);

            //var common = new CommonEntity(
            // GuidGenerator.Create(),
            // code, name, status, linked
            // );

            var newEntity = new TCommonEntity
            {
                Code = code,
                Name = name,
                Status = status,
                Linked = linked
            };
            newEntity.SetId(GuidGenerator.Create());
            return await _repository.InsertAsync(newEntity);
        }

        public async Task<TCommonEntity> CreateAsync(TCommonEntity baseEntity)
        {
            return await _repository.InsertAsync(baseEntity);
        }

        public async Task<TCommonEntity> UpdateAsync(
            Guid id,
            string code, string name, Status? status = null, Guid? linked = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), CommonEntityConsts.CodeMaxLength, CommonEntityConsts.CodeMinLength);
            Check.Length(name, nameof(name), CommonEntityConsts.NameMaxLength);

            var entity = await _repository.GetAsync(id);
            entity.Code = code;
            entity.Name = name;
            entity.Status = status;
            entity.Linked = linked;
            entity.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _repository.UpdateAsync(entity);
        }
    }
}
