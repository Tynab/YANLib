﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YANLib.Entities;

[Table("Developers")]
public sealed class Developer
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string IdCard { get; set; }
    public int DeveloperTypeCode { get; set; }
    public bool IsActive { get; set; }
    public int Version { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("DeveloperTypeCode")]
    public DeveloperType DeveloperType { get; set; }
}