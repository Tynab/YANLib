using System;
using System.ComponentModel.DataAnnotations;

namespace YANLib;

public class YANLibApplicationListQuery
{
    [Range(1, 100)]
    public byte PageNumber { get; set; } = 1;

    [Range(1, 100)]
    public byte PageSize { get; set; } = 10;
}
