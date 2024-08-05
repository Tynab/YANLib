namespace YANLib.Requests.Insert;

public sealed class DeveloperInsertRequest : YANLibApplicationInsertRequest
{
    public required string Name { get; set; }

    public string? Phone { get; set; }

    public required string IdCard { get; set; }

    public required long DeveloperTypeCode { get; set; }
}
