using System;

namespace DDDInheritance.CommonEntities
{
    public class CommonEntityExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string FilterText { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }

        public CommonEntityExcelDownloadDto()
        {

        }
    }
}
