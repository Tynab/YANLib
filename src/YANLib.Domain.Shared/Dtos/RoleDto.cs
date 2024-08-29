using System;

namespace YANLib.Dtos;

public sealed record RoleDto
{
    public Guid RoleId { get; set; }

    public string? RoleName { get; set; }
}
