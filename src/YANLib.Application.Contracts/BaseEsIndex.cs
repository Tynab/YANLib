using Nest;

namespace YANLib;

public class BaseEsIndex<TId>
{
    public required TId Id { get; set; }

    public required Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    [Keyword]
    public bool IsActive { get; set; }
}
