using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace DDDInheritance.CommonEntities
{
    public interface IBaseEntity : IMultiTenant, IEntity<Guid>, IAggregateRoot<Guid>, IHasConcurrencyStamp
    {
        string Code { get; set; }

        string Name { get; set; }

        Status? Status { get; set; }

        Guid? Linked { get; set; }

       void SetId(Guid id);
    }
}
