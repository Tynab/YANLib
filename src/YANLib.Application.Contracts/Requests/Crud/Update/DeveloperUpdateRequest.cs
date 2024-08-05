namespace YANLib.Requests.Crud.Update;

public sealed class DeveloperUpdateRequest : YANLibApplicationUpdateRequest
{
    public required string Name { get; set; }

    public string? Phone { get; set; }

    public required string IdCard { get; set; }

    public required long DeveloperTypeCode { get; set; }

    public required int Version { get; set; }
}
