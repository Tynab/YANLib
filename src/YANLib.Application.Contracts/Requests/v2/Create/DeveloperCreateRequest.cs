namespace YANLib.Requests.v2.Create;

public sealed class DeveloperCreateRequest : YANLibApplicationCreateRequest
{
    public required string Name { get; set; }

    public string? Phone { get; set; }

    public required string IdCard { get; set; }

    public required long DeveloperTypeCode { get; set; }
}
