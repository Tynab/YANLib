namespace YANLib.Blazor.Client;

public abstract class YANLibComponentBase : AbpComponentBase
{
    protected YANLibComponentBase()
    {
        LocalizationResource = typeof(YANLibResource);
    }
}
