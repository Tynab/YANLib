using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using YANLib.Object;
using YANLib.Unmanaged;
using static System.Convert;
using static System.DateTime;
using static System.Net.HttpStatusCode;
using static System.StringSplitOptions;
using static System.Text.Encoding;

namespace YANLib.Middlewares;

public class SwaggerBasicAuthMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private readonly RequestDelegate _next = next;
    private readonly IConfiguration _configuration = configuration;

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            string? authHeader = context.Request.Headers.Authorization;

            if (authHeader.IsNotNullNWhiteSpace() && authHeader.StartsWith("Basic "))
            {
                var newVarName = authHeader.Split(' ', 2, RemoveEmptyEntries)[1]?.Trim();

                if (newVarName.IsNullOWhiteSpace())
                {
                    return;
                }

                var decoded = UTF8.GetString(FromBase64String(newVarName))?.Split(':', 2);

                if (decoded.IsNotNullNEmpty() && IsAuthorized(decoded[0], decoded[1]))
                {
                    await _next.Invoke(context);

                    return;
                }
            }

            context.Response.Headers.WWWAuthenticate = "Basic";
            context.Response.StatusCode = Unauthorized.To<int>();
        }
        else
        {
            await _next.Invoke(context);
        }
    }

    private bool IsAuthorized(string username, string password) => username.Equals($"{_configuration["Auth:Username"]}{Today.Day}") && password.Equals($"{_configuration["Auth:Password"]}{UtcNow.Minute}");
}
