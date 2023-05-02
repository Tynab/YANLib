using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.HttpStatusCode;

namespace YANLib.Demo;

public static partial class YANHttpClient
{
    private static async ValueTask<T?> GetApiAsync<T>(this HttpClient httpClient, string uri, string param, string? path = null, string? authorization = null, JsonSerializerOptions? serializerOptions = null) where T : class, new()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(authorization))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorization);
            }
            httpClient.BaseAddress = new Uri(uri);
            var options = serializerOptions ?? new JsonSerializerOptions();
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            var response = await httpClient.GetFromJsonAsync<JsonElement>(param);
            if (path is null)
            {
                return JsonSerializer.Deserialize<T>(response.GetRawText(), options);
            }
            var subJson = response.GetProperty(path);
            return JsonSerializer.Deserialize<T>(subJson.GetRawText(), options);
        }
        catch (HttpRequestException)
        {
            return default;
        }
        catch (JsonException)
        {
            return default;
        }
        catch (KeyNotFoundException)
        {
            return default;
        }
        catch (Exception)
        {
            return default;
        }
    }

    private static async Task<T?> PostApiAsync<T>(string uri, string param, object data, string? authorization = null) where T : class, new()
    {
        var httpCl = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(7000)
        };
        if (authorization != null)
        {
            httpCl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorization);
        }
        httpCl.BaseAddress = new Uri(uri);

        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        var resp = await httpCl.PostAsync(param, content);
        if (resp.StatusCode == HttpStatusCode.OK)
        {
            var stream = await resp.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            try
            {
                var json = await JsonSerializer.DeserializeAsync<JsonElement>(stream);
                var jsonStr = json.GetRawText();
                return JsonSerializer.Deserialize<T>(jsonStr, options);
            }
            catch (JsonException)
            {
                return default;
            }
        }
        else
        {
            return default;
        }
    }
}
