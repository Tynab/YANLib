using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using YANLib.Core;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static Serilog.Log;
using static System.Net.HttpStatusCode;

namespace YANLib.Middlewares;

public class UnauthorizedHandlerMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        var writeCustomResponse = false;
        var originalResponse = context.Response.Body;
        var newResponse = new MemoryStream();

        context.Response.Body = newResponse;

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Error(ex, "UnauthorizedHandlerMiddleware-Exception");
            context.Response.StatusCode = Status500InternalServerError;
        }
        finally
        {
            context.Response.Body = originalResponse;
            newResponse.Position = default;

            using var cloneResponse = new MemoryStream();

            newResponse.CopyTo(cloneResponse);
            cloneResponse.Position = default;

            using var reader = new StreamReader(cloneResponse);

            writeCustomResponse = (await reader.ReadToEndAsync()).StartsWith("Access Denied");

            newResponse.Position = default;
        }

        if (writeCustomResponse)
        {
            context.Response.StatusCode = Unauthorized.ToInt();
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync("Access Denied");
        }
        else
        {
            await newResponse.CopyToAsync(context.Response.Body, context.RequestAborted);
        }
    }
}
