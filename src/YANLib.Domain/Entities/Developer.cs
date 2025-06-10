using System;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Guid;
using static YANLib.YANLibConsts.DbSchema;

namespace YANLib.Entities;

[Table(nameof(Developer), Schema = Sample)]
public sealed class Developer : YANLibDomainEntity<Guid>
{
    public Developer() => Id = NewGuid();

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? IdCard { get; set; }

    public long DeveloperTypeCode { get; set; }

    public int RawVersion { get; set; } = 1;
}
