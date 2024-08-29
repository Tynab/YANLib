using System;
using System.Collections.Generic;

namespace YANLib.Dtos;

public sealed record UserDto
{
    public Guid UserId { get; set; }

    public string? UserName { get; set; }

    public string? PassWord { get; set; }

    public List<RoleDto>? Roles { get; set; }
}
