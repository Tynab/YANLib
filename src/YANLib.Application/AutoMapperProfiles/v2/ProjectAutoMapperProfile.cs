using AutoMapper;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AutoMapper;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.Responses;
using static System.DateTime;

namespace YANLib.AutoMapperProfiles.v2;

public sealed class ProjectAutoMapperProfile : Profile
{
    public ProjectAutoMapperProfile()
    {
        _ = CreateMap<(string Id, Requests.v2.Create.ProjectCreateRequest Request), Project>()
            .ForMember(d => d.Id, o => o.MapFrom(static s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(static s => s.Request.Name))
            .ForMember(d => d.Description, o => o.MapFrom(static s => s.Request.Description))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(static s => s.Request.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(static s => UtcNow))
            .ForMember(d => d.IsActive, o => o.MapFrom(static s => true))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(static s => false))
            .Ignore(static d => d.UpdatedBy)
            .Ignore(static d => d.UpdatedAt);

        _ = CreateMap<(string Id, Requests.v2.Update.ProjectUpdateRequest Request), ProjectDto>()
            .ForMember(d => d.Id, o => o.MapFrom(static s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(static s => s.Request.Name))
            .ForMember(d => d.Description, o => o.MapFrom(static s => s.Request.Description))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(static s => s.Request.UpdatedBy))
            .ForMember(d => d.IsActive, o => o.MapFrom(static s => s.Request.IsActive))
            .Ignore(static d => d.IsDeleted);

        _ = CreateMap<Project, ProjectEsIndex>();

        _ = CreateMap<ProjectEsIndex, ProjectResponse>();

        CreateMap<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>().ConvertUsing((source, dest, context)
            => new PagedResultDto<ProjectResponse>(source.TotalCount, context.Mapper.Map<IReadOnlyList<ProjectResponse>>(source.Items)));
    }
}
