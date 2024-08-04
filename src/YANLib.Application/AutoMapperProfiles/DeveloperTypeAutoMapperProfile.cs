using AutoMapper;
using System;
using System.Collections.Generic;
using Volo.Abp.AutoMapper;
using YANLib.Core;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;
using static System.DateTime;

namespace YANLib.AutoMapperProfiles;

public sealed class DeveloperTypeAutoMapperProfile : Profile
{
    public DeveloperTypeAutoMapperProfile()
    {
        _ = CreateMap<DeveloperTypeInsertRequest, DeveloperType>()
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => UtcNow))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => true))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(s => false))
            .Ignore(d => d.UpdatedBy)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<(Guid Id, DeveloperTypeModifyRequest Request), DeveloperTypeDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Request.Name))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Request.UpdatedBy))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Request.IsActive))
            .Ignore(d => d.IsDeleted);

        _ = CreateMap<DeveloperType, RedisDtos.DeveloperRedisTypeDto>()
            .ForMember(d => d.DeveloperTypeId, o => o.MapFrom(s => s.Id));

        _ = CreateMap<DeveloperType, DeveloperTypeResponse>();

        _ = CreateMap<RedisDtos.DeveloperRedisTypeDto, DeveloperTypeResponse>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.DeveloperTypeId))
            .Ignore(d => d.Code);

        _ = CreateMap<KeyValuePair<string, RedisDtos.DeveloperRedisTypeDto>, DeveloperTypeResponse>()
            .ForMember(d => d.Code, o => o.MapFrom(s => s.Key.ToLong(default)))
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Value.DeveloperTypeId))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Value.Name))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Value.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.Value.CreatedAt))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Value.UpdatedBy))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => s.Value.UpdatedAt))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Value.IsActive));
    }
}
