using System;
using System.Text.Json.Serialization;

namespace YANLib.Responses;

public sealed record JsonResponse
{
    [JsonPropertyName("IdOptionalName")]
    public Guid Id { get; set; }
}
