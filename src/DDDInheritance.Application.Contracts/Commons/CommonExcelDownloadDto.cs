using DDDInheritance;
using Volo.Abp.Application.Dtos;
using System;

namespace DDDInheritance.Commons
{
    public class CommonExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string FilterText { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public Guid? Linked { get; set; }

        public CommonExcelDownloadDto()
        {

        }
    }
}