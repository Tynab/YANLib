//using AutoMapper;
//using Volo.Abp.AutoMapper;
//using YANLib.Entities;
//using YANLib.EsIndices;
//using YANLib.Requests.Insert;
//using YANLib.Responses;
//using static System.DateTime;

//namespace YANLib.AutoMapperProfiles;

//public sealed class DeveloperAutoMapperProfile : Profile
//{
//    public DeveloperAutoMapperProfile()
//    {
//        _ = CreateMap<DeveloperEsIndex, DeveloperResponse>()
//            .ForMember(d => d.Id, o => o.MapFrom(s => s.DeveloperId))
//            .ForMember(d => d.IdCard, o => o.MapFrom(s => s.Id));

//        _ = CreateMap<DeveloperInsertRequest, Developer>()
//            .ForMember(d => d.Version, o => o.MapFrom(s => 1))
//            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => UtcNow))
//            .ForMember(d => d.IsActive, o => o.MapFrom(s => true))
//            .ForMember(d => d.IsDeleted, o => o.MapFrom(s => false))
//            .Ignore(d => d.Id)
//            .Ignore(d => d.UpdatedBy)
//            .Ignore(d => d.UpdatedAt);

//        _ = CreateMap<Developer, DeveloperResponse>()
//            .Ignore(d => d.DeveloperType)
//            .Ignore(d => d.Certificates);
//        //
//        _ = CreateMap<DeveloperResponse, DeveloperEsIndex>()
//            .ForMember(d => d.Id, o => o.MapFrom(s => s.IdCard))
//            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Id));

//        _ = CreateMap<Developer, DeveloperEsIndex>()
//            .ForMember(d => d.Id, o => o.MapFrom(s => s.IdCard))
//            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Id))
//            .Ignore(d => d.Certificates);

//        _ = CreateMap<DeveloperEsIndex, Developer>()
//            .ForMember(d => d.Id, o => o.MapFrom(s => s.DeveloperId))
//            .ForMember(d => d.DeveloperTypeCode, o => o.MapFrom(s => s.DeveloperType.Code))
//            .Ignore(d => d.DeveloperType);
//    }
//}
