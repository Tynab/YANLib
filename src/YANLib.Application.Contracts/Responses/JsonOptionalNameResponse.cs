using System;
using System.Text.Json.Serialization;

namespace YANLib.Responses;

public sealed record JsonOptionalNameResponse
{
    [JsonPropertyName("IdOptionalName")]
    public Guid Id { get; set; }
}
