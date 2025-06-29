﻿using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NUglify.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using static System.DateTime;

namespace YANLib.Options;

public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IWebHostEnvironment environment) : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider = provider;
    private readonly IWebHostEnvironment _environment = environment;

    public void Configure(SwaggerGenOptions options) => _provider.ApiVersionDescriptions.ForEach(x => options.SwaggerDoc(x.GroupName, CreateInfoForApiVersion(x)));

    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = $"{typeof(ConfigureSwaggerOptions).Namespace?.Split('.')[0]} API - {_environment.EnvironmentName}",
            Version = description.ApiVersion.ToString(),
        };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }
        else
        {
            info.Description += $" Deployed At: {UtcNow:yyyy-MM-dd HH:mm:ss}";
        }

        return info;
    }
}
