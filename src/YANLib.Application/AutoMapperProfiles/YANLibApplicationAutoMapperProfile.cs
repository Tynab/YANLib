using AutoMapper;
using YANLib.Entities;
using YANLib.Requests.Developer;

namespace YANLib.Profiles;

public class YANLibApplicationAutoMapperProfile : Profile
{
    public YANLibApplicationAutoMapperProfile()
    {
        _ = CreateMap<DeveloperCreateRequest.Certificate, Certificate>();

        _ = CreateMap<DeveloperUpdateRequest.Certificate, Certificate>();
    }
}
