using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NUglify.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using static System.DateTime;

namespace YANLib.Options;

public class ConfigureSwaggerOption(IApiVersionDescriptionProvider provider, IWebHostEnvironment environment) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options) => provider.ApiVersionDescriptions.ForEach(x => options.SwaggerDoc(x.GroupName, CreateInfoForApiVersion(x)));

    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = $"{typeof(ConfigureSwaggerOption).Namespace?.Split('.')[1]} API - {environment.EnvironmentName}",
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
