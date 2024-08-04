namespace YANLib.Entities;

public sealed class Developer : YANLibDomainEntity
{
    public string Name { get; set; }

    public string Phone { get; set; }

    public string IdCard { get; set; }

    public long DeveloperTypeCode { get; set; }

    public int Version { get; set; }
}
