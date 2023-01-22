using System;
using Volo.Abp.Application.Dtos;

namespace DDDInheritance.CommonEntities
{
    public class GetCommonEntitiesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }

        public GetCommonEntitiesInput()
        {

        }
    }
}
