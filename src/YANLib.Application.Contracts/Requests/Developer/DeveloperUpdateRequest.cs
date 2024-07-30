using System;
using System.Collections.Generic;

namespace YANLib.Requests.Developer;

public sealed class DeveloperUpdateRequest : YANLibUpdateRequest
{
    public required string Name { get; set; }

    public string Phone { get; set; }

    public required string IdCard { get; set; }

    public required Guid DeveloperTypeId { get; set; }

    public int Version { get; set; }
}
