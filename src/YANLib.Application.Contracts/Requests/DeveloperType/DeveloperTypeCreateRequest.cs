namespace YANLib.Requests.DeveloperType;

public sealed class DeveloperTypeCreateRequest
{
    public required int Code { get; set; }

    public required string Name { get; set; }

    public bool IsActive { get; set; } = true;
}
