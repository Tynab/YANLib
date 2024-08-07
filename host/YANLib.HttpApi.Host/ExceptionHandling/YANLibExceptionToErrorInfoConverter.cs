using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ExceptionHandling.Localization;
using Volo.Abp.Http;
using Volo.Abp.Localization.ExceptionHandling;
using YANLib.Core;
using static System.Reflection.BindingFlags;
using static YANLib.YANLibDomainErrorMessages;

namespace YANLib.ExceptionHandling;

[Dependency(ReplaceServices = true)]
public class YANLibExceptionToErrorInfoConverter(
    IOptions<AbpExceptionLocalizationOptions> localizationOptions,
    IStringLocalizerFactory stringLocalizerFactory,
    IStringLocalizer<AbpExceptionHandlingResource> stringLocalizer,
    IServiceProvider serviceProvider
) : DefaultExceptionToErrorInfoConverter(localizationOptions, stringLocalizerFactory, stringLocalizer, serviceProvider), ITransientDependency
{
    private readonly HashSet<string?> _errorCodes = new(typeof(YANLibDomainErrorCodes).GetFields(Public | Static | FlattenHierarchy)
                                                                                      .Where(x => x.IsLiteral && !x.IsInitOnly)
                                                                                      .Select(x => x.GetRawConstantValue()?.ToString())
                                                                                      .Where(x => x.IsNotNull()));

    protected override RemoteServiceErrorInfo CreateErrorInfoWithoutCode(Exception exception, AbpExceptionHandlingOptions options)
    {
        var code = exception.GetType()?.GetProperty("Code")?.GetValue(exception);

        if (code.IsNull())
        {
            return new YANLibExtensibleRemoteServiceErrorInfo(INTERNAL_SERVER_ERROR, exception.Message, YANLibDomainErrorCodes.INTERNAL_SERVER_ERROR);
        }
        else
        {
            if (exception.Message.IsNotWhiteSpaceAndNull() && !_errorCodes.Contains(code))
            {
                var details = exception.GetType()?.GetProperty("Details")?.GetValue(exception);

                return details.IsNull()
                    ? new YANLibExtensibleRemoteServiceErrorInfo(exception.Message, string.Empty, code.ToString())
                    : new YANLibExtensibleRemoteServiceErrorInfo(exception.Message, details.ToString(), code.ToString()) as RemoteServiceErrorInfo;
            }

            options.SendExceptionsDetailsToClients = false;
            options.SendStackTraceToClients = false;

            return base.CreateErrorInfoWithoutCode(exception, options);
        }
    }
}
