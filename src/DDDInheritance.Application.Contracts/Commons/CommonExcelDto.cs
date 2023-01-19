using DDDInheritance;
using System;

namespace DDDInheritance.Commons
{
    public class CommonExcelDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }
    }
}