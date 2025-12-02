using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ExceptionHandling.Localization;
using Volo.Abp.Http;
using Volo.Abp.Localization.ExceptionHandling;
using YANLib;
using static YANLib.BaseErrorCodes;
using static System.Reflection.BindingFlags;
using EOE.CCSBE.ExceptionHandling;

namespace YANLib.ExceptionHandling;

[Dependency(ReplaceServices = true)]
public class BaseExceptionToErrorInfoConverter(
    IOptions<AbpExceptionLocalizationOptions> localizationOptions,
    IStringLocalizerFactory stringLocalizerFactory,
    IStringLocalizer<AbpExceptionHandlingResource> stringLocalizer,
    IServiceProvider serviceProvider
) : DefaultExceptionToErrorInfoConverter(localizationOptions, stringLocalizerFactory, stringLocalizer, serviceProvider), ITransientDependency
{
    private readonly HashSet<string?> _errorCodes = [.. typeof(BaseErrorCodes).GetFields(Public | Static | FlattenHierarchy)
        .Where(static x => x.IsLiteral && !x.IsInitOnly)
        .Select(static x => x.GetRawConstantValue()?.ToString())
        .Where(static x => x.IsNotNull())];

    protected override RemoteServiceErrorInfo CreateErrorInfoWithoutCode(Exception exception, AbpExceptionHandlingOptions options)
    {
        var code = exception.GetType()?.GetProperty("Code")?.GetValue(exception);

        if (code.IsNull())
        {
            return new BaseExtensibleRemoteServiceErrorInfo(INTERNAL_SERVER_ERROR, exception.Message, BaseErrorCodes.INTERNAL_SERVER_ERROR);
        }
        else
        {
            if (exception.Message.IsNotNullWhiteSpace() && !_errorCodes.Contains(code))
            {
                var details = exception.GetType()?.GetProperty("Details")?.GetValue(exception);

                return details.IsNull()
                    ? new BaseExtensibleRemoteServiceErrorInfo(exception.Message, string.Empty, code.ToString())
                    : new BaseExtensibleRemoteServiceErrorInfo(exception.Message, details.ToString(), code.ToString()) as RemoteServiceErrorInfo;
            }

            options.SendExceptionsDetailsToClients = false;
            options.SendStackTraceToClients = false;

            return base.CreateErrorInfoWithoutCode(exception, options);
        }
    }
}
