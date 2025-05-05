namespace YANLib.Requests.v2.Update;

public sealed class DeveloperUpdateRequest : YANLibApplicationUpdateRequest
{
    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? IdCard { get; set; }

    public long? DeveloperTypeCode { get; set; }
}
