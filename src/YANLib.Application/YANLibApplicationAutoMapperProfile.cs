namespace YANLib;

public class YANLibApplicationAutoMapperProfile : Profile
{
    public YANLibApplicationAutoMapperProfile()
    {
        _ = CreateMap<DeveloperCreateRequest.Certificate, Certificate>();

        _ = CreateMap<DeveloperUpdateRequest.Certificate, Certificate>();
    }
}
