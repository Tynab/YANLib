using System;

namespace YANLib.Dtos;

public class DeveloperProjectDto : YANLibDomainDto<Guid>
{
    public Guid DeveloperId { get; set; }

    public string? ProjectId { get; set; }
}
