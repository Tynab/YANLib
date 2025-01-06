using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using NUglify.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using YANLib.Object;
using static Swashbuckle.AspNetCore.SwaggerGen.OpenApiAnyFactory;
using static System.Text.Json.JsonSerializer;

namespace YANLib.Options;

public class SwaggerDefaultValues : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var apiDescription = context.ApiDescription;

        operation.Deprecated |= apiDescription.IsDeprecated();

        context.ApiDescription.SupportedResponseTypes.ForEach(x =>
        {
            var response = operation.Responses[x.IsDefaultResponse ? "default" : x.StatusCode.ToString()];

            response.Content.Keys.ForEach(y =>
            {
                if (!x.ApiResponseFormats.Any(x => x.MediaType == y))
                {
                    _ = response.Content.Remove(y);
                }
            });
        });

        if (operation.Parameters.IsNullEmpty())
        {
            return;
        }

        operation.Parameters.ForEach(x =>
        {
            var description = apiDescription.ParameterDescriptions.FirstOrDefault(p => p.Name == x.Name);

            if (description.IsNull())
            {
                return;
            }

            if (x.Description.IsNullEmpty())
            {
                x.Description = description.ModelMetadata?.Description;
            }

            if (x.Schema.Default.IsNull() && description.DefaultValue.IsNotNull())
            {
                x.Schema.Default = CreateFromJson(Serialize(description.DefaultValue, description.ModelMetadata?.ModelType ?? typeof(object)));
            }

            x.Required |= description.IsRequired;
        });
    }
}
