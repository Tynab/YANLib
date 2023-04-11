using System.Text;
using System.Text.Json;
using static System.Text.Json.JsonNamingPolicy;

namespace YANLib;

public static partial class YANJson
{
    public static string Serialize<T>(this T mdl) where T : class => JsonSerializer.Serialize(mdl);

    public static async IAsyncEnumerable<string> Serialize<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is not null && mdls.Any())
        {
            var opts = new JsonSerializerOptions();
            foreach (var mdl in mdls)
            {
                await using var stream = new MemoryStream();
                await using (var writer = new Utf8JsonWriter(stream))
                {
                    JsonSerializer.Serialize(writer, mdl, opts);
                }
                yield return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
        else
        {
            yield break;
        }
    }

    public static string SerializeCamel<T>(this T mdl) where T : class => JsonSerializer.Serialize(mdl, new JsonSerializerOptions
    {
        PropertyNamingPolicy = CamelCase,
        PropertyNameCaseInsensitive = false
    });

    public static T? Deserialize<T>(this string str) where T : class
    {
        try
        {
            return JsonSerializer.Deserialize<T>(str);
        }
        catch
        {
            return default;
        }
    }

    public static T? DeserializeCamel<T>(this string str) where T : class
    {
        try
        {
            return JsonSerializer.Deserialize<T>(str, new JsonSerializerOptions
            {
                PropertyNamingPolicy = CamelCase,
                PropertyNameCaseInsensitive = false
            });
        }
        catch
        {
            return default;
        }
    }

    public static T? DeserializeStandard<T>(this string str) where T : class
    {
        T? rslt;
        try
        {
            rslt = JsonSerializer.Deserialize<T>(str);
        }
        catch
        {
            rslt = default;
        }
        if (rslt == null || rslt.AllPropertiesDefault())
        {
            try
            {
                rslt = JsonSerializer.Deserialize<T>(str, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = CamelCase,
                    PropertyNameCaseInsensitive = false
                });
            }
            catch
            {
                rslt = default;
            }
        }
        return rslt;
    }
}
