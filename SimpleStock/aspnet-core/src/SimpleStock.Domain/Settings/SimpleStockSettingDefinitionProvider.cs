using Volo.Abp.Settings;

namespace SimpleStock.Settings;

public class SimpleStockSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SimpleStockSettings.MySetting1));
    }
}
