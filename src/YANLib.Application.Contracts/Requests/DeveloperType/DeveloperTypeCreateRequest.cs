namespace YANLib.Requests.DeveloperType;

public sealed class DeveloperTypeCreateRequest
{
    public required long Code { get; set; }

    public required string Name { get; set; }

    public bool IsActive { get; set; } = true;
}
