using System.ComponentModel.DataAnnotations.Schema;
using YANLib;
using YANLib.Enums;
using static YANLib.BaseConsts;
using static System.Guid;

namespace YANLib.Entities;

[Table("Samples", Schema = DbSchema.Sample)]
public sealed class Sample : BaseEntity
{
    public Sample() => Id = NewGuid();

    public string? Name { get; set; }

    public string? Description { get; set; }

    public SampleType? Type { get; set; }
}
