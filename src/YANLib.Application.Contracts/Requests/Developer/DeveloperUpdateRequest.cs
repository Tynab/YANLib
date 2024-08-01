using System;

namespace YANLib.Requests.Developer;

public sealed class DeveloperUpdateRequest : YANLibApplicationUpdateRequest
{
    public string Name { get; set; }

    public string Phone { get; set; }

    public string IdCard { get; set; }

    public required Guid DeveloperTypeId { get; set; }
}
