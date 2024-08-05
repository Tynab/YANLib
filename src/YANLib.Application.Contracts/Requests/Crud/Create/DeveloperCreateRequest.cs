using System.ComponentModel;

namespace YANLib.Requests.Crud.Create;

public sealed class DeveloperCreateRequest : YANLibApplicationCreateRequest
{
    public required string Name { get; set; }

    public string? Phone { get; set; }

    public required string IdCard { get; set; }

    public required long DeveloperTypeCode { get; set; }

    [DefaultValue(1)]
    public required int Version { get; set; } = 1;
}
