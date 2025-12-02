using Microsoft.AspNetCore.Mvc.ModelBinding;
using Volo.Abp.AspNetCore.Mvc.Validation;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;
using static YANLib.BaseErrorCodes;

namespace YANLib.Validations;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IModelStateValidator))]
public class BaseModelStateValidator : ModelStateValidator
{
    public override void Validate(ModelStateDictionary modelState)
    {
        var validationResult = new AbpValidationResult();

        base.AddErrors(validationResult, modelState);

        if (validationResult.Errors.Count is not 0)
        {
            throw new BaseValidationException(BAD_REQUEST, "Model state is not valid!", validationResult.Errors);
        }
    }
}
