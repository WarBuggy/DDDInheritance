using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace DDDInheritance.CommonEntities
{
    public abstract class CommonEntity : FullAuditedAggregateRoot<Guid>, IBaseEntity
    {
        public Guid? TenantId { get; set; }
        [NotNull]
        public string Code { get; set; }
        [CanBeNull]
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }

        public CommonEntity()
        {

        }

        public CommonEntity(Guid id, string code, string name, Status? status = null, Guid? linked = null)
        {

            Id = id;
            Check.NotNull(code, nameof(code));
            Check.Length(code, nameof(code), CommonEntityConsts.CodeMaxLength, CommonEntityConsts.CodeMinLength);
            Check.Length(name, nameof(name), CommonEntityConsts.NameMaxLength, 0);
            Code = code;
            Name = name;
            Status = status;
            Linked = linked;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
