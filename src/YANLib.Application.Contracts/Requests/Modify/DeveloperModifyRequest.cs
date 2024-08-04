namespace YANLib.Requests.Modify;

public sealed class DeveloperModifyRequest : YANLibApplicationModifyRequest
{
    public string Name { get; set; }

    public string Phone { get; set; }

    public string IdCard { get; set; }

    public long? DeveloperTypeCode { get; set; }
}
