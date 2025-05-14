using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;

namespace YANLib.AutoMapperProfiles.v1;

public sealed class DeveloperTypeAutoMapperProfile : Profile
{
    public DeveloperTypeAutoMapperProfile()
    {
        _ = CreateMap<DeveloperTypeCreateRequest, DeveloperType>()
            .Ignore(static d => d.UpdatedBy)
            .Ignore(static d => d.UpdatedAt);

        _ = CreateMap<DeveloperTypeUpdateRequest, DeveloperType>();

        _ = CreateMap<DeveloperType, DeveloperTypeResponse>();
    }
}
