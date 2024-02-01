using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests.Developer;

public sealed class DeveloperUpdateRequest
{
    public string Name { get; set; }

    public string Phone { get; set; }

    public int? DeveloperTypeCode { get; set; }

    public List<Certificate> Certificates { get; set; }

    public sealed class Certificate
    {
        [Required]
        public string Name { get; set; }

        public double? GPA { get; set; }
    }
}
