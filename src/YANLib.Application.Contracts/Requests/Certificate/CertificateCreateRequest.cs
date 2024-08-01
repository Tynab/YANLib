﻿using System;

namespace YANLib.Requests.Certificate;

public sealed class CertificateCreateRequest : YANLibApplicationCreateRequest
{
    public required string Name { get; set; }

    public double? GPA { get; set; }

    public required Guid DeveloperId { get; set; }
}