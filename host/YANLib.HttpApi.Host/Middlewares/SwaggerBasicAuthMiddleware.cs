using YANLib;
using YANLib.Options;
using static System.Convert;
using static System.Net.HttpStatusCode;
using static System.StringSplitOptions;
using static System.Text.Encoding;

namespace YANLib.Middlewares;

public class SwaggerBasicAuthMiddleware(RequestDelegate next, IConfiguration configuration)
{
    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            string? authHeader = context.Request.Headers.Authorization;

            if (authHeader.IsNotNullWhiteSpace() && authHeader.StartsWith("Basic "))
            {
                var newVarName = authHeader.Split(' ', 2, RemoveEmptyEntries)[1]?.Trim();

                if (newVarName.IsNullWhiteSpace())
                {
                    return;
                }

                var decoded = UTF8.GetString(FromBase64String(newVarName))?.Split(':', 2);

                if (decoded.IsNotNullEmpty() && IsAuthorized(decoded[0], decoded[1]))
                {
                    await next.Invoke(context);

                    return;
                }
            }

            context.Response.Headers.WWWAuthenticate = "Basic";
            context.Response.StatusCode = Unauthorized.Parse<int>();
        }
        else
        {
            await next.Invoke(context);
        }
    }

    private bool IsAuthorized(string username, string password)
    {
        var auth = configuration.GetSection("Auth").Get<AuthOption>() ?? new();

        return username.Equals(auth.Username) && password.Equals(auth.Password);
    }
}
