using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib.Dtos;

public sealed record RoleDto
{
    public Guid RoleId { get; set; }

    public string? RoleName { get; set; }
}
