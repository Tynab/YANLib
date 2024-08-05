using Volo.Abp.Data;
using Volo.Abp.Http;

namespace YANLib.ExceptionHandling;

public class YANLibExtensibleRemoteServiceErrorInfo : RemoteServiceErrorInfo, IHasExtraProperties
{
    public YANLibExtensibleRemoteServiceErrorInfo() { }

    public YANLibExtensibleRemoteServiceErrorInfo(string message, string? details = null, string? code = null) : base(message, details, code) { }

    public ExtraPropertyDictionary ExtraProperties { get; set; }
}
