using System;

namespace YANLib.Dtos;

public class JsonDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public uint Income { get; set; }
    public bool IsRisk { get; set; }
}
