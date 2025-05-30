using Nest;
using System;
using System.Security.Cryptography;

namespace YANLib;

[ElasticsearchType(IdProperty = nameof(Id))]
public class YANLibApplicationEsIndex<TId>
{
    public required TId Id { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Keyword]
    public bool IsActive { get; set; }
}
