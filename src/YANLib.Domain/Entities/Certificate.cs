using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YANLib.Entities;

public sealed class Certificate : YANLibEntity
{
    public string Code { get; set; }

    public string Name { get; set; }

    public double? GPA { get; set; }

    public Guid DeveloperId { get; set; }
}
