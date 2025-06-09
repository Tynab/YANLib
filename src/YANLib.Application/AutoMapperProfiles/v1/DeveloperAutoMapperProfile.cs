using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;

namespace YANLib.AutoMapperProfiles.v1;

public sealed class DeveloperAutoMapperProfile : Profile
{
    public DeveloperAutoMapperProfile()
    {
        _ = CreateMap<DeveloperCreateRequest, Developer>()
            .Ignore(static d => d.UpdatedBy)
            .Ignore(static d => d.UpdatedAt);

        _ = CreateMap<DeveloperUpdateRequest, Developer>();

        _ = CreateMap<Developer, DeveloperResponse>()
            .AfterMap(static (s, d) =>
            {
                if (d.DeveloperType.IsNull())
                {
                    d.DeveloperType = new DeveloperTypeResponse
                    {
                        Id = s.DeveloperTypeCode
                    };
                }
                else
                {
                    d.DeveloperType.Id = s.DeveloperTypeCode;
                }
            });
    }
}
