using AutoMapper;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AutoMapper;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using static System.DateTime;

namespace YANLib.AutoMapperProfiles.v2;

public sealed class ProjectAutoMapperProfile : Profile
{
    public ProjectAutoMapperProfile()
    {
        _ = CreateMap<(string Id, ProjectCreateRequest Request), Project>()
            .ForMember(static d => d.Id, static o => o.MapFrom(static s => s.Id))
            .ForMember(static d => d.Name, static o => o.MapFrom(static s => s.Request.Name))
            .ForMember(static d => d.Description, static o => o.MapFrom(static s => s.Request.Description))
            .ForMember(static d => d.CreatedBy, static o => o.MapFrom(static s => s.Request.CreatedBy))
            .ForMember(static d => d.CreatedAt, static o => o.MapFrom(static s => UtcNow))
            .ForMember(static d => d.IsActive, static o => o.MapFrom(static s => true))
            .ForMember(static d => d.IsDeleted, static o => o.MapFrom(static s => false))
            .Ignore(static d => d.UpdatedBy)
            .Ignore(static d => d.UpdatedAt);

        _ = CreateMap<(string Id, ProjectUpdateRequest Request), ProjectDto>()
            .ForMember(static d => d.Id, static o => o.MapFrom(static s => s.Id))
            .ForMember(static d => d.Name, static o => o.MapFrom(static s => s.Request.Name))
            .ForMember(static d => d.Description, static o => o.MapFrom(static s => s.Request.Description))
            .ForMember(static d => d.UpdatedBy, static o => o.MapFrom(static s => s.Request.UpdatedBy))
            .ForMember(static d => d.IsActive, static o => o.MapFrom(static s => s.Request.IsActive))
            .Ignore(static d => d.IsDeleted);

        _ = CreateMap<Project, ProjectEsIndex>();

        _ = CreateMap<ProjectEsIndex, ProjectResponse>();

        CreateMap<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>().ConvertUsing((source, dest, context)
            => new PagedResultDto<ProjectResponse>(source.TotalCount, context.Mapper.Map<IReadOnlyList<ProjectResponse>>(source.Items)));
    }
}
