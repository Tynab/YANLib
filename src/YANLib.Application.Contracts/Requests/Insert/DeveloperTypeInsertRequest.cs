namespace YANLib.Requests.Insert;

public sealed class DeveloperTypeInsertRequest : YANLibApplicationInsertRequest
{
    public required string Name { get; set; }
}
