using AutoMapper;
using System.Collections.Generic;
using Volo.Abp.AutoMapper;
using YANLib.Core;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;
using static System.DateTime;

namespace YANLib.AutoMapperProfiles;

public sealed class DeveloperTypeAutoMapperProfile : Profile
{
    public DeveloperTypeAutoMapperProfile()
    {
        _ = CreateMap<DeveloperTypeCreateRequest, DeveloperType>()
            .Ignore(d => d.UpdatedBy)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<DeveloperTypeUpdateRequest, DeveloperType>();

        _ = CreateMap<DeveloperType, DeveloperTypeResponse>();

        _ = CreateMap<(long Id, Requests.v2.Create.DeveloperTypeCreateRequest Request), DeveloperType>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Request.Name))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Request.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => UtcNow))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => true))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(s => false))
            .Ignore(d => d.UpdatedBy)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<(long Id, Requests.v2.Update.DeveloperTypeUpdateRequest Request), DeveloperTypeDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Request.Name))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Request.UpdatedBy))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Request.IsActive))
            .Ignore(d => d.IsDeleted);

        _ = CreateMap<DeveloperType, DeveloperTypeRedisDto>();

        _ = CreateMap<(long Id, DeveloperTypeRedisDto Dto), DeveloperTypeResponse>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Dto.Name))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Dto.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.Dto.CreatedAt))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Dto.UpdatedBy))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => s.Dto.UpdatedAt))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Dto.IsActive));

        _ = CreateMap<KeyValuePair<string, DeveloperTypeRedisDto?>, DeveloperTypeResponse>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Key.To<long>()))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Value.IsNull() ? default : s.Value.Name))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Value.IsNull() ? default : s.Value.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.Value.IsNull() ? default : s.Value.CreatedAt))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Value.IsNull() ? default : s.Value.UpdatedBy))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => s.Value.IsNull() ? default : s.Value.UpdatedAt))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Value.IsNotNull() && s.Value.IsActive));
    }
}
