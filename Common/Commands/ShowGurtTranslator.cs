using ModDeTchass.Content.UI;
using Terraria.ModLoader;
using Terraria.UI;

namespace ModDeTchass.Common.Commands;

public class ShowGurtTranslator : ModCommand
{
    public override CommandType Type => CommandType.Chat;
    public override string Command => "gurttranslator";
    public override string Description => "Shows Gurt Translator";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        IngameFancyUI.OpenUIState(GurtTranslator.Instance);
    }
}