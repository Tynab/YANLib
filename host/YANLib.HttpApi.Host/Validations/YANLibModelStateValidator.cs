using Microsoft.AspNetCore.Mvc.ModelBinding;
using Volo.Abp.AspNetCore.Mvc.Validation;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;
using YANLib.Core;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IModelStateValidator))]
public class YANLibModelStateValidator : ModelStateValidator
{
    public override void Validate(ModelStateDictionary modelState)
    {
        var validationResult = new AbpValidationResult();

        base.AddErrors(validationResult, modelState);

        if (validationResult.Errors.IsNotEmptyAndNull())
        {
            throw new YANLibValidationException(BAD_REQUEST, "Model state is not valid!", validationResult.Errors);
        }
    }
}
