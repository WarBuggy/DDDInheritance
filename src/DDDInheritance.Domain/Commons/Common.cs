using DDDInheritance;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace DDDInheritance.Commons
{
    public abstract class Common : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Code { get; set; }

        [CanBeNull]
        public virtual string Name { get; set; }

        public virtual Status? Status { get; set; }

        public virtual Guid? Linked { get; set; }

        public Common()
        {

        }

        public Common(Guid id, string code, string name, Status? status = null, Guid? linked = null)
        {

            Id = id;
            Check.NotNull(code, nameof(code));
            Check.Length(code, nameof(code), CommonConsts.CodeMaxLength, CommonConsts.CodeMinLength);
            Check.Length(name, nameof(name), CommonConsts.NameMaxLength, 0);
            Code = code;
            Name = name;
            Status = status;
            Linked = linked;
        }

    }
}