using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;

namespace YANLib.AutoMapperProfiles.v1;

public sealed class ProjectAutoMapperProfile : Profile
{
    public ProjectAutoMapperProfile()
    {
        _ = CreateMap<ProjectCreateRequest, Project>()
            .Ignore(static d => d.UpdatedBy)
            .Ignore(static d => d.UpdatedAt);

        _ = CreateMap<ProjectUpdateRequest, Project>();

        _ = CreateMap<Project, ProjectResponse>();
    }
}
