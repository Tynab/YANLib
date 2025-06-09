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

        CreateMap<(Guid DeveloperId, KeyValuePair<string, DeveloperProjectRedisDto?> Pair), DeveloperProjectResponse?>().ConvertUsing(static (s, _) => s.Pair.Value.IsNull()
            ? null
            : new DeveloperProjectResponse
            {
                Id = s.Pair.Value.Id,
                DeveloperId = s.DeveloperId,
                ProjectId = s.Pair.Key,
                CreatedBy = s.Pair.Value.CreatedBy,
                CreatedAt = s.Pair.Value.CreatedAt,
                UpdatedBy = s.Pair.Value.UpdatedBy,
                UpdatedAt = s.Pair.Value.UpdatedAt,
                IsActive = s.Pair.Value.IsActive
            });

        _ = CreateMap<(Guid DeveloperId, string ProjectId, DeveloperProjectRedisDto Dto), DeveloperProjectResponse>()
            .ForMember(static d => d.DeveloperId, static o => o.MapFrom(static s => s.DeveloperId))
            .ForMember(static d => d.ProjectId, static o => o.MapFrom(static s => s.ProjectId))
            .ForMember(static d => d.Id, static o => o.MapFrom(static s => s.Dto.Id))
            .ForMember(static d => d.CreatedBy, static o => o.MapFrom(static s => s.Dto.CreatedBy))
            .ForMember(static d => d.CreatedAt, static o => o.MapFrom(static s => s.Dto.CreatedAt))
            .ForMember(static d => d.UpdatedBy, static o => o.MapFrom(static s => s.Dto.UpdatedBy))
            .ForMember(static d => d.UpdatedAt, static o => o.MapFrom(static s => s.Dto.UpdatedAt))
            .ForMember(static d => d.IsActive, static o => o.MapFrom(static s => s.Dto.IsActive));
    }
}
