using DDDInheritance.Web.Pages.Commons;
using Volo.Abp.AutoMapper;
using DDDInheritance.Commons;
using AutoMapper;

namespace DDDInheritance.Web;

public class DDDInheritanceWebAutoMapperProfile : Profile
{
    public DDDInheritanceWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.

        CreateMap<CommonDto, CommonUpdateViewModel>();
        CreateMap<CommonUpdateViewModel, CommonUpdateDto>();
        CreateMap<CommonCreateViewModel, CommonCreateDto>();
    }
}