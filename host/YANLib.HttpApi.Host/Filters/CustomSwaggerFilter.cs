using Microsoft.OpenApi.Models;
using NUglify.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using static System.StringComparison;

namespace YANLib.Filters;

public class CustomSwaggerFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context) => swaggerDoc.Paths.Where(x => x.Key.ToLowerInvariant().StartsWith("/api/abp", InvariantCultureIgnoreCase)).ForEach(x => swaggerDoc.Paths.Remove(x.Key));
}
