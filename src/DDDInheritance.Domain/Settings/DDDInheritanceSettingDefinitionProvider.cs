using Volo.Abp.Settings;

namespace DDDInheritance.Settings;

public class DDDInheritanceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(DDDInheritanceSettings.MySetting1));
    }
}
