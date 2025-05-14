using AutoMapper;
using System.Collections.Generic;
using Volo.Abp.AutoMapper;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Responses;
using static System.DateTime;

namespace YANLib.AutoMapperProfiles.v2;

public sealed class DeveloperTypeAutoMapperProfile : Profile
{
    public DeveloperTypeAutoMapperProfile()
    {
        _ = CreateMap<(long Id, Requests.v2.Create.DeveloperTypeCreateRequest Request), DeveloperType>()
            .ForMember(d => d.Id, o => o.MapFrom(static s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(static s => s.Request.Name))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(static s => s.Request.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(static s => UtcNow))
            .ForMember(d => d.IsActive, o => o.MapFrom(static s => true))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(static s => false))
            .Ignore(static d => d.UpdatedBy)
            .Ignore(static d => d.UpdatedAt);

        _ = CreateMap<(long Id, Requests.v2.Update.DeveloperTypeUpdateRequest Request), DeveloperTypeDto>()
            .ForMember(d => d.Id, o => o.MapFrom(static s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(static s => s.Request.Name))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(static s => s.Request.UpdatedBy))
            .ForMember(d => d.IsActive, o => o.MapFrom(static s => s.Request.IsActive))
            .Ignore(static d => d.IsDeleted);

        _ = CreateMap<DeveloperType, DeveloperTypeRedisDto>();

        _ = CreateMap<(long Id, DeveloperTypeRedisDto Dto), DeveloperTypeResponse>()
            .ForMember(d => d.Id, o => o.MapFrom(static s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(static s => s.Dto.Name))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(static s => s.Dto.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(static s => s.Dto.CreatedAt))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(static s => s.Dto.UpdatedBy))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(static s => s.Dto.UpdatedAt))
            .ForMember(d => d.IsActive, o => o.MapFrom(static s => s.Dto.IsActive));

        _ = CreateMap<KeyValuePair<string, DeveloperTypeRedisDto?>, DeveloperTypeResponse>()
            .ForMember(d => d.Id, o => o.MapFrom(static s => s.Key.Parse<long>()))
            .ForMember(d => d.Name, o => o.MapFrom(static s => s.Value.IsNull() ? default : s.Value.Name))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(static s => s.Value.IsNull() ? default : s.Value.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(static s => s.Value.IsNull() ? default : s.Value.CreatedAt))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(static s => s.Value.IsNull() ? default : s.Value.UpdatedBy))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(static s => s.Value.IsNull() ? default : s.Value.UpdatedAt))
            .ForMember(d => d.IsActive, o => o.MapFrom(static s => s.Value.IsNotNull() && s.Value.IsActive));
    }
}
