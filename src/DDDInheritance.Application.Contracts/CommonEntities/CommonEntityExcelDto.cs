using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInheritance.CommonEntities
{
    public class CommonEntityExcelDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }
    }
}
