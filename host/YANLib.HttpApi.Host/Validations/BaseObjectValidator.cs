using Microsoft.Extensions.Options;
using NUglify.Helpers;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;
using YANLib;
using static YANLib.BaseErrorCodes;
using static System.Threading.Tasks.Task;

namespace YANLib.Validations;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IObjectValidator))]
public class BaseObjectValidator(IOptions<AbpValidationOptions> options, IServiceScopeFactory serviceScopeFactory) : IObjectValidator, ITransientDependency
{
    protected AbpValidationOptions Options { get; } = options.Value;

    protected IServiceScopeFactory ServiceScopeFactory { get; } = serviceScopeFactory;

    public virtual async Task ValidateAsync(object validatingObject, string? name = null, bool allowNull = false)
    {
        var errors = await GetErrorsAsync(validatingObject, name, allowNull);

        if (errors.IsNotNullEmpty())
        {
            throw new BaseValidationException(BAD_REQUEST, "Object state is not valid!", errors);
        }
    }

    public virtual async Task<List<ValidationResult>> GetErrorsAsync(object validatingObject, string? name = null, bool allowNull = false)
    {
        if (validatingObject.IsNull())
        {
            return await FromResult(allowNull ? [] : new List<ValidationResult>
            {
                name.IsNull() ? new ValidationResult("Given object is null!") : new ValidationResult($"{name} is null!", [name])
            });
        }

        var context = new ObjectValidationContext(validatingObject);

        using var scope = ServiceScopeFactory.CreateScope();

        Options.ObjectValidationContributors.ForEach(async x =>
        {
            var objectValidationContributor = scope.ServiceProvider.GetRequiredService(x) as IObjectValidationContributor;

            if (objectValidationContributor.IsNull())
            {
                return;
            }

            await objectValidationContributor.AddErrorsAsync(context);
        });

        return await FromResult(context.Errors);
    }
}
