﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YANLib.Entities;

[Table("Certificates")]
public sealed class Certificate
{
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }

    public double? GPA { get; set; }

    public string DeveloperId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
