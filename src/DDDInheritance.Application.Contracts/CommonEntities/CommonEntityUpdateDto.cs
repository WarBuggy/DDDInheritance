using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace DDDInheritance.CommonEntities
{
    public class CommonEntityUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(CommonEntityConsts.CodeMaxLength, MinimumLength = CommonEntityConsts.CodeMinLength)]
        public string Code { get; set; }
        [StringLength(CommonEntityConsts.NameMaxLength)]
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}
