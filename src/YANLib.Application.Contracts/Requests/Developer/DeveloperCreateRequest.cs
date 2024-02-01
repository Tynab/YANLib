using System.Collections.Generic;

namespace YANLib.Requests.Developer;

public sealed class DeveloperCreateRequest
{
    public required string Name { get; set; }

    public string Phone { get; set; }

    public required string IdCard { get; set; }

    public required int DeveloperTypeCode { get; set; }

    public List<Certificate> Certificates { get; set; }

    public sealed class Certificate
    {
        public required string Name { get; set; }

        public double? GPA { get; set; }
    }
}
