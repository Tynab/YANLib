using System;
using System.Reflection;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;
using YANLib.Object;
using static Volo.Abp.Check;
using static Volo.Abp.Reflection.ReflectionHelper;
using static Volo.Abp.Reflection.TypeHelper;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IMethodInvocationValidator))]
public class YANLibMethodInvocationValidator(IObjectValidator objectValidator) : IMethodInvocationValidator, ITransientDependency
{
    private readonly IObjectValidator _objectValidator = objectValidator;

    public virtual async Task ValidateAsync(MethodInvocationValidationContext context)
    {
        _ = NotNull(context, nameof(context));

        if (context.Parameters.IsNullOEmpty())
        {
            return;
        }

        if (!context.Method.IsPublic)
        {
            return;
        }

        if (IsValidationDisabled(context))
        {
            return;
        }

        if (context.Parameters.Length != context.ParameterValues.Length)
        {
            throw new ArgumentException("Method parameter count does not match with argument count!");
        }

        if (context.Errors.IsNotNullNEmpty() && HasSingleNullArgument(context))
        {
            ThrowValidationError(context);
        }

        await AddMethodParameterValidationErrorsAsync(context);

        if (context.Errors.IsNotNullNEmpty())
        {
            ThrowValidationError(context);
        }
    }

    protected virtual bool IsValidationDisabled(MethodInvocationValidationContext context)
        => !context.Method.IsDefined(typeof(EnableValidationAttribute), true) && GetSingleAttributeOfMemberOrDeclaringTypeOrDefault<DisableValidationAttribute>(context.Method).IsNotNull();

    protected virtual bool HasSingleNullArgument(MethodInvocationValidationContext context) => context.Parameters.Length is 1 && context.ParameterValues[0].IsNull();

    protected virtual void ThrowValidationError(MethodInvocationValidationContext context) => throw new YANLibValidationException(BAD_REQUEST, "Method arguments are not valid!", context.Errors);

    protected virtual async Task AddMethodParameterValidationErrorsAsync(MethodInvocationValidationContext context)
    {
        for (var i = 0; i < context.Parameters.Length; i++)
        {
            await AddMethodParameterValidationErrorsAsync(context, context.Parameters[i], context.ParameterValues[i]);
        }
    }

    protected virtual async Task AddMethodParameterValidationErrorsAsync(IAbpValidationResult context, ParameterInfo parameterInfo, object parameterValue) => context.Errors.AddRange(await _objectValidator.GetErrorsAsync(
        parameterValue,
        parameterInfo.Name,
        parameterInfo.IsOptional || parameterInfo.IsOut || IsPrimitiveExtended(parameterInfo.ParameterType, includeEnums: true)
    ));
}
