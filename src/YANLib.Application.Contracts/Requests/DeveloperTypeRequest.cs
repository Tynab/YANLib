using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public sealed class DeveloperTypeRequest
{
    [Required]
    public int Code { get; set; }

    [Required]
    public string Name { get; set; }

    public bool IsActive { get; set; } = true;
}
