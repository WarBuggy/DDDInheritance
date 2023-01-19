using System;
using Volo.Abp.Domain.Entities;

namespace DDDInheritance.Commons
{
    public interface ICommon : IEntity
    {
        Guid? TenantId { get; set; }

        string Code { get; set; }

        string Name { get; set; }

        Status? Status { get; set; }

        Guid? Linked { get; set; }
    }
}
