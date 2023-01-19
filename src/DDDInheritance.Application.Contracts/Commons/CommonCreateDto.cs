using DDDInheritance;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DDDInheritance.Commons
{
    public class CommonCreateDto
    {
        [Required]
        [StringLength(CommonConsts.CodeMaxLength, MinimumLength = CommonConsts.CodeMinLength)]
        public string Code { get; set; }
        [StringLength(CommonConsts.NameMaxLength)]
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }
    }
}