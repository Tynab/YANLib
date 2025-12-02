using System.ComponentModel;

namespace YANLib;

public class BaseCreateOrUpdateRequest
{
    [DefaultValue(true)]
    public bool? IsActive { get; set; } = true;
}
