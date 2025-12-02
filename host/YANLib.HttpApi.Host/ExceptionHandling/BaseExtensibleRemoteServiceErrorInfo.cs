using Volo.Abp.Data;
using Volo.Abp.Http;

namespace YANLib.ExceptionHandling;

public class BaseExtensibleRemoteServiceErrorInfo : RemoteServiceErrorInfo, IHasExtraProperties
{
    public BaseExtensibleRemoteServiceErrorInfo()
    {
    }

    public BaseExtensibleRemoteServiceErrorInfo(string message, string? details = null, string? code = null) : base(message, details, code)
    {
    }

    public ExtraPropertyDictionary ExtraProperties { get; set; } = [];
}
