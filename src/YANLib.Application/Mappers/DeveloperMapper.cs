using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Entities;
using YANLib.EsIndexes;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Mappers;

public sealed class DeveloperMapper : Profile
{
    public DeveloperMapper()
    {
        _ = CreateMap<DeveloperIndex, DeveloperResponse>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.DeveloperId));

        _ = CreateMap<Developer, DeveloperResponse>()
            .Ignore(d => d.DeveloperType)
            .Ignore(d => d.Certificates);

        _ = CreateMap<DeveloperResponse, DeveloperIndex>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.IdCard))
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Id));

        _ = CreateMap<Developer, DeveloperIndex>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.IdCard))
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Id))
            .Ignore(d => d.DeveloperType)
            .Ignore(d => d.Certificates);

        _ = CreateMap<DeveloperRequest, Developer>()
            .Ignore(d => d.IsActive)
            .Ignore(d => d.Version)
            .Ignore(d => d.CreatedDate)
            .Ignore(d => d.ModifiedDate);

        _ = CreateMap<DeveloperIndex, Developer>()
            .ForMember(d => d.DeveloperTypeCode, o => o.MapFrom(s => s.DeveloperType.Code))
            .Ignore(d => d.Id);
    }
}
