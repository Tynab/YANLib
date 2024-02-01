using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;

namespace YANLib.Middlewares;

public class SwaggerBasicAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _config;

    public SwaggerBasicAuthMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _config = config;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                var username = decodedUsernamePassword.Split(':', 2)[0];
                var password = decodedUsernamePassword.Split(':', 2)[1];

                if (IsAuthorized(username, password))
                {
                    await _next.Invoke(context);
                    return;
                }
            }

            context.Response.Headers["WWW-Authenticate"] = "Basic";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else
        {
            await _next.Invoke(context);
        }
    }

    private bool IsAuthorized(string username, string password)
    {
        var _userName = "qq";
        var _password = "cc";

        return username.Equals(_userName, StringComparison.InvariantCultureIgnoreCase) && password.Equals(_password);
    }
}
