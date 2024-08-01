using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.Requests.Developer;
using YANLib.Responses;

namespace YANLib.AutoMapperProfiles;

public sealed class DeveloperProfile : Profile
{
    public DeveloperProfile()
    {
        _ = CreateMap<DeveloperIndex, DeveloperResponse>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.DeveloperId));

        _ = CreateMap<Developer, DeveloperResponse>()
            .Ignore(d => d.Certificates);

        _ = CreateMap<DeveloperResponse, DeveloperIndex>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.IdCard))
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Id));

        _ = CreateMap<Developer, DeveloperIndex>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.IdCard))
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Id))
            .Ignore(d => d.Certificates);

        _ = CreateMap<DeveloperCreateRequest, Developer>()
            .Ignore(d => d.Id)
            .Ignore(d => d.IsActive)
            .Ignore(d => d.Version)
            .Ignore(d => d.CreatedAt)
            .Ignore(d => d.UpdatedAt)
            .Ignore(d => d.DeveloperType);

        _ = CreateMap<DeveloperIndex, Developer>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.DeveloperId))
            .ForMember(d => d.DeveloperTypeId, o => o.MapFrom(s => s.DeveloperType.Code))
            .Ignore(d => d.DeveloperType);
    }
}
