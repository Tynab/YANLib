using System;
using System.ComponentModel.DataAnnotations;

namespace YANLib.ListQueries.v2;

public sealed class DeveloperProjectListQuery : YANLibApplicationListQuery
{
    [Required]
    public Guid DeveloperId { get; set; }
}
