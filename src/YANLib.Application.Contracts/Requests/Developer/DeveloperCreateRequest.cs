using System;

namespace YANLib.Requests.Developer;

public sealed class DeveloperCreateRequest : YANLibApplicationCreateRequest
{
    public required string Name { get; set; }

    public string Phone { get; set; }

    public required string IdCard { get; set; }

    public required Guid DeveloperTypeId { get; set; }
}
