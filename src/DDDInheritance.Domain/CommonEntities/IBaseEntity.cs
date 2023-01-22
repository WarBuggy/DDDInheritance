using System;
using Volo.Abp.Domain.Entities;

namespace DDDInheritance.CommonEntities
{
    public interface IBaseEntity : IEntity<Guid>
    {
        string Code { get; set; }

        string Name { get; set; }

        Status? Status { get; set; }

        Guid? Linked { get; set; }
    }
}
