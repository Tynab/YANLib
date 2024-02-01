using Volo.Abp.Settings;

namespace YANLib.Settings;

public class YANLibSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(YANLibSettings.MySetting1));
    }
}
