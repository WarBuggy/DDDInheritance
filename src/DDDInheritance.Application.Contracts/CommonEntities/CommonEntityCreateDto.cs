using System;
using System.ComponentModel.DataAnnotations;

namespace DDDInheritance.CommonEntities
{
    public class CommonEntityCreateDto
    {
        [Required]
        [StringLength(CommonEntityConsts.CodeMaxLength, MinimumLength = CommonEntityConsts.CodeMinLength)]
        public string Code { get; set; }
        [StringLength(CommonEntityConsts.NameMaxLength)]
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }
    }
}
