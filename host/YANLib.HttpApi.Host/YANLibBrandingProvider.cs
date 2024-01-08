namespace YANLib;

[Dependency(ReplaceServices = true)]
public class YANLibBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "YANLib";
}
