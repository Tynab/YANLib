using AutoMapper;
using System;
using System.Collections.Generic;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Responses;

namespace YANLib.AutoMapperProfiles.v2;

public sealed class DeveloperProjectAutoMapperProfile : Profile
{
    public DeveloperProjectAutoMapperProfile()
    {
        _ = CreateMap<DeveloperProject, DeveloperProjectRedisDto>();

        _ = CreateMap<(Guid DeveloperId, KeyValuePair<string, DeveloperProjectRedisDto?> Pair), DeveloperProjectResponse>()
            .ForMember(d => d.DeveloperId, o => o.MapFrom(static s => s.DeveloperId))
            .ForMember(d => d.ProjectId, o => o.MapFrom(static s => s.Pair.Key))
            .ForMember(d => d.Id, o => o.MapFrom(static s => s.Pair.Value.IsNull() ? default : s.Pair.Value.Id))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(static s => s.Pair.Value.IsNull() ? default : s.Pair.Value.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(static s => s.Pair.Value.IsNull() ? default : s.Pair.Value.CreatedAt))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(static s => s.Pair.Value.IsNull() ? default : s.Pair.Value.UpdatedBy))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(static s => s.Pair.Value.IsNull() ? default : s.Pair.Value.UpdatedAt))
            .ForMember(d => d.IsActive, o => o.MapFrom(static s => s.Pair.Value.IsNotNull() && s.Pair.Value.IsActive));

        _ = CreateMap<(Guid DeveloperId, string ProjectId, DeveloperProjectRedisDto Dto), DeveloperProjectResponse>()
            .ForMember(d => d.DeveloperId, o => o.MapFrom(static s => s.DeveloperId))
            .ForMember(d => d.ProjectId, o => o.MapFrom(static s => s.ProjectId))
            .ForMember(d => d.Id, o => o.MapFrom(static s => s.Dto.Id))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(static s => s.Dto.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(static s => s.Dto.CreatedAt))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(static s => s.Dto.UpdatedBy))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(static s => s.Dto.UpdatedAt))
            .ForMember(d => d.IsActive, o => o.MapFrom(static s => s.Dto.IsActive));
    }
}
