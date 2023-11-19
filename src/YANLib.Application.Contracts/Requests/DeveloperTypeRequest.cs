namespace YANLib.Requests;

public sealed class DeveloperTypeRequest
{
    public required int Code { get; set; }

    public required string Name { get; set; }

    public bool IsActive { get; set; } = true;
}
