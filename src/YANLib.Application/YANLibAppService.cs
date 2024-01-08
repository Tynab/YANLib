namespace YANLib;

public abstract class YANLibAppService : ApplicationService
{
    protected YANLibAppService() => LocalizationResource = typeof(YANLibResource);
}
