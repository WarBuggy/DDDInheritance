using System;
using DDDInheritance.Shared;
using Volo.Abp.AutoMapper;
using DDDInheritance.Commons;
using AutoMapper;
using DDDInheritance.CommonEntities;

namespace DDDInheritance;

public class DDDInheritanceApplicationAutoMapperProfile : Profile
{
    public DDDInheritanceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<IBaseEntity, CommonEntityDto>();
        CreateMap<IBaseEntity, CommonEntityExcelDto>();
    }
}