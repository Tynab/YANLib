namespace YANLib.Requests.DeveloperType;

public sealed class DeveloperTypeUpdateRequest : YANLibApplicationUpdateRequest
{
    public required long Code { get; set; }

    public string Name { get; set; }
}
