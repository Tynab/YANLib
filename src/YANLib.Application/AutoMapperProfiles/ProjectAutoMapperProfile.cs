using AutoMapper;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AutoMapper;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;
using static System.DateTime;

namespace YANLib.AutoMapperProfiles;

public sealed class ProjectAutoMapperProfile : Profile
{
    public ProjectAutoMapperProfile()
    {
        _ = CreateMap<ProjectCreateRequest, Project>()
            .Ignore(d => d.UpdatedBy)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<ProjectUpdateRequest, Project>();

        _ = CreateMap<Project, ProjectResponse>();

        _ = CreateMap<(string Id, Requests.v2.Create.ProjectCreateRequest Request), Project>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Request.Name))
            .ForMember(d => d.Description, o => o.MapFrom(s => s.Request.Description))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Request.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => UtcNow))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => true))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(s => false))
            .Ignore(d => d.UpdatedBy)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<(string Id, Requests.v2.Update.ProjectUpdateRequest Request), ProjectDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Request.Name))
            .ForMember(d => d.GPA, o => o.MapFrom(s => s.Request.GPA))
            .ForMember(d => d.Description, o => o.MapFrom(s => s.Request.Description))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Request.UpdatedBy))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Request.IsActive))
            .Ignore(d => d.IsDeleted);

        _ = CreateMap<Project, ProjectEsIndex>();

        _ = CreateMap<ProjectEsIndex, ProjectResponse>();

        CreateMap<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>().ConvertUsing((source, dest, context)
            => new PagedResultDto<ProjectResponse>(source.TotalCount, context.Mapper.Map<IReadOnlyList<ProjectResponse>>(source.Items)));
    }
}
