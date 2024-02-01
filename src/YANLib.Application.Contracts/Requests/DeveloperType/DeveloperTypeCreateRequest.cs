using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests.DeveloperType;

public sealed class DeveloperTypeCreateRequest
{
    [Required]
    public int Code { get; set; }

    [Required]
    public string Name { get; set; }

    public bool IsActive { get; set; } = true;
}
