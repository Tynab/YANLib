namespace YANLib;

public abstract class YANLibController : AbpControllerBase
{
    protected YANLibController() => LocalizationResource = typeof(YANLibResource);
}
