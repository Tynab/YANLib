﻿using Nest;
using System.Collections.Generic;

namespace YANLib.EsIndices;

public sealed class ProjectEsIndex : YANLibApplicationEsIndex<string>
{
    [Keyword]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Nested]
    public List<DeveloperEsIndex>? Developers { get; set; }
}
