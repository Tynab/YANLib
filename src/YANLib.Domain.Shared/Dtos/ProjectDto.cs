﻿namespace YANLib.Dtos;

public sealed class ProjectDto : YANLibDomainDto<string>
{
    public string? Name { get; set; }

    public string? Description { get; set; }
}
