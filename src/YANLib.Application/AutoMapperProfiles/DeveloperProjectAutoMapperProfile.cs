using AutoMapper;
using System;
using System.Collections.Generic;
using Volo.Abp.AutoMapper;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;
using static System.DateTime;

namespace YANLib.AutoMapperProfiles;

public sealed class DeveloperProjectAutoMapperProfile : Profile
{
    public DeveloperProjectAutoMapperProfile()
    {
        _ = CreateMap<DeveloperProjectCreateRequest, DeveloperProject>()
            .Ignore(d => d.UpdatedBy)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<DeveloperProjectUpdateRequest, DeveloperProject>();

        _ = CreateMap<DeveloperProject, DeveloperProjectResponse>();

        _ = CreateMap<(Guid DeveloperId, string ProjectId, Requests.v2.Create.DeveloperProjectCreateRequest Request), DeveloperProject>()
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.DeveloperId))
            .ForMember(d => d.ProjectId, o => o.MapFrom(s => s.ProjectId))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Request.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => UtcNow))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => true))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(s => false))
            .Ignore(d => d.UpdatedBy)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<(Guid Id, Requests.v2.Update.DeveloperProjectUpdateRequest Request), DeveloperProjectDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Request.DeveloperId))
            .ForMember(d => d.ProjectId, o => o.MapFrom(s => s.Request.ProjectId))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Request.UpdatedBy))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Request.IsActive))
            .Ignore(d => d.IsDeleted);

        _ = CreateMap<DeveloperProject, DeveloperProjectRedisDto>();

        _ = CreateMap<(Guid DeveloperId, string ProjectId, DeveloperProject Entity), DeveloperProjectResponse>()
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.DeveloperId))
            .ForMember(d => d.ProjectId, o => o.MapFrom(s => s.ProjectId))
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Entity.Id))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Entity.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.Entity.CreatedAt))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Entity.UpdatedBy))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => s.Entity.UpdatedAt))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Entity.IsActive));

        _ = CreateMap<(Guid DeveloperId, KeyValuePair<string, DeveloperProjectRedisDto?> Pair), DeveloperProjectResponse>()
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.DeveloperId))
            .ForMember(d => d.ProjectId, o => o.MapFrom(s => s.Pair.Key))
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Pair.Value.IsNull() ? default : s.Pair.Value.Id))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Pair.Value.IsNull() ? default : s.Pair.Value.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.Pair.Value.IsNull() ? default : s.Pair.Value.CreatedAt))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Pair.Value.IsNull() ? default : s.Pair.Value.UpdatedBy))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => s.Pair.Value.IsNull() ? default : s.Pair.Value.UpdatedAt))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Pair.Value.IsNotNull() && s.Pair.Value.IsActive));

        _ = CreateMap<(Guid DeveloperId, string ProjectId, DeveloperProjectRedisDto Dto), DeveloperProjectResponse>()
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.DeveloperId))
            .ForMember(d => d.ProjectId, o => o.MapFrom(s => s.ProjectId))
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Dto.Id))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Dto.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.Dto.CreatedAt))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Dto.UpdatedBy))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => s.Dto.UpdatedAt))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Dto.IsActive));
    }
}
