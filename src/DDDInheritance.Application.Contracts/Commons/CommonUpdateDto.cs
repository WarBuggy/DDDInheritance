using DDDInheritance;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace DDDInheritance.Commons
{
    public class CommonUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(CommonConsts.CodeMaxLength, MinimumLength = CommonConsts.CodeMinLength)]
        public string Code { get; set; }
        [StringLength(CommonConsts.NameMaxLength)]
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}