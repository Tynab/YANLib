using AutoMapper;
using YANLib.Entities;
using YANLib.Requests;

namespace YANLib;

public class YANLibApplicationAutoMapperProfile : Profile
{
    public YANLibApplicationAutoMapperProfile()
    {
        _ = CreateMap<DeveloperRequest.Certificate, Certificate>();

        _ = CreateMap<DeveloperAdjustRequest.Certificate, Certificate>();
    }
}
