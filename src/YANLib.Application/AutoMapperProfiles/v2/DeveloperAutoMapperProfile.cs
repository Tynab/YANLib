using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.ElasticsearchIndices;
using YANLib.Entities;
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
        _ = CreateMap<DeveloperElasticsearchIndex, DeveloperResponse>().ReverseMap();

        _ = CreateMap<DeveloperCreateRequest, Developer>()
            .ForMember(d => d.Id, o => o.MapFrom(static s => NewGuid()))
            .ForMember(d => d.RawVersion, o => o.MapFrom(static s => 1))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(static s => UtcNow))
            .ForMember(d => d.IsActive, o => o.MapFrom(static s => true))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(static s => false))
            .Ignore(static d => d.UpdatedBy)
            .Ignore(static d => d.UpdatedAt);

        _ = CreateMap<DeveloperUpdateRequest, Developer>()
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(static s => UtcNow))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(static s => false))
            .Ignore(static d => d.Id)
            .Ignore(static d => d.RawVersion)
            .Ignore(static d => d.CreatedBy)
            .Ignore(static d => d.CreatedAt);

        _ = CreateMap<Developer, DeveloperElasticsearchIndex>()
            .Ignore(static d => d.DeveloperType)
            .Ignore(static d => d.Projects);

        //_ = CreateMap<Developer, DeveloperResponse>()
        //    .Ignore(d => d.DeveloperType)
        //    .Ignore(d => d.Certificates);
        ////
        //_ = CreateMap<DeveloperResponse, DeveloperEsIndex>()
        //    .ForMember(d => d.Id, o => o.MapFrom(s => s.IdCard))
        //    .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Id));

        //_ = CreateMap<Developer, DeveloperEsIndex>()
        //    .ForMember(d => d.Id, o => o.MapFrom(s => s.IdCard))
        //    .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Id))
        //    .Ignore(d => d.Certificates);

        //_ = CreateMap<DeveloperEsIndex, Developer>()
        //    .ForMember(d => d.Id, o => o.MapFrom(s => s.DeveloperId))
        //    .ForMember(d => d.DeveloperTypeCode, o => o.MapFrom(s => s.DeveloperType.Code))
        //    .Ignore(d => d.DeveloperType);
    }
}
