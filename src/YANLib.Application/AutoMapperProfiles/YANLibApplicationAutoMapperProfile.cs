using AutoMapper;
using YANLib.Entities;
using YANLib.Requests.Crud.Update;
using YANLib.Requests.Insert;

namespace YANLib.Profiles;

public class YANLibApplicationAutoMapperProfile : Profile
{
    public YANLibApplicationAutoMapperProfile()
    {
        _ = CreateMap<DeveloperInsertRequest.Certificate, Certificate>();

        _ = CreateMap<DeveloperUpdateRequest.Certificate, Certificate>();
    }
}
