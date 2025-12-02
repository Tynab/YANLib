namespace YANLib;

public class BaseRedisDto
{
    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
