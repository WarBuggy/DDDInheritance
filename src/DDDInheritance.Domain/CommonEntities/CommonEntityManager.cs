using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;
using Volo.Abp;

namespace DDDInheritance.CommonEntities
{
    public class CommonEntityManager<T, TRepository> : DomainService, ICommonEntityManager<T, TRepository>
       where T : class, IBaseEntity, new()
       where TRepository : class, ICommonEntityRepository<T>
    {
        protected readonly TRepository _repository;

        public CommonEntityManager(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<T> CreateAsync(string code, string name, 
            Status? status = null, Guid? linked = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), CommonEntityConsts.CodeMaxLength, CommonEntityConsts.CodeMinLength);
            Check.Length(name, nameof(name), CommonEntityConsts.NameMaxLength);

            var newEntity = new T
            {
                Code = code,
                Name = name,
                Status = status,
                Linked = linked
            };
            newEntity.SetId(GuidGenerator.Create());
            return await _repository.InsertAsync(newEntity);
        }

        public async Task<T> CreateAsync(T baseEntity)
        {
            return await _repository.InsertAsync(baseEntity);
        }

        public async Task<T> UpdateAsync(
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
