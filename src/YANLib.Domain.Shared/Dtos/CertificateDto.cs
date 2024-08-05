﻿using System;

namespace YANLib.Dtos;

public sealed class CertificateDto : YANLibDomainDto
{
    public string? Name { get; set; }

    public double? GPA { get; set; }

    public Guid? DeveloperId { get; set; }
}
