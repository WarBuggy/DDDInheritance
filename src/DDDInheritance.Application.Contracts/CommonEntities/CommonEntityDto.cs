using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace DDDInheritance.CommonEntities
{
    public class CommonEntityDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}
