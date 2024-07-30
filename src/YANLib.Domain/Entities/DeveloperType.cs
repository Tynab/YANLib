using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace YANLib.Entities;

public sealed class DeveloperType : YANLibEntity
{
    public long Code { get; set; }

    public string Name { get; set; }
}
