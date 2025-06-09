using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using static System.DateTime;
using static System.Guid;

namespace YANLib.AutoMapperProfiles.v2;

public sealed class DeveloperAutoMapperProfile : Profile
{
    public DeveloperAutoMapperProfile()
    {
        _ = CreateMap<DeveloperEsIndex, DeveloperResponse>().ReverseMap();

        _ = CreateMap<DeveloperCreateRequest, Developer>()
            .ForMember(static d => d.Id, static o => o.MapFrom(static s => NewGuid()))
            .ForMember(static d => d.RawVersion, static o => o.MapFrom(static s => 1))
            .ForMember(static d => d.CreatedAt, static o => o.MapFrom(static s => UtcNow))
            .ForMember(static d => d.IsActive, static o => o.MapFrom(static s => true))
            .ForMember(static d => d.IsDeleted, static o => o.MapFrom(static s => false))
            .Ignore(static d => d.UpdatedBy)
            .Ignore(static d => d.UpdatedAt);

        _ = CreateMap<DeveloperUpdateRequest, Developer>()
            .ForMember(static d => d.UpdatedAt, static o => o.MapFrom(static s => UtcNow))
            .ForMember(static d => d.IsDeleted, static o => o.MapFrom(static s => false))
            .Ignore(static d => d.Id)
            .Ignore(static d => d.RawVersion)
            .Ignore(static d => d.CreatedBy)
            .Ignore(static d => d.CreatedAt);

        _ = CreateMap<Developer, DeveloperEsIndex>()
            .Ignore(static d => d.DeveloperType)
            .Ignore(static d => d.Projects);
    }
}
