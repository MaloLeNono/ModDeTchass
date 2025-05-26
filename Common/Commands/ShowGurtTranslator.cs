using ModDeTchass.Content.UI;
using Steamworks;
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
        if (SteamUser.GetSteamID().m_SteamID != 76561198068879376)
            return;
        
        IngameFancyUI.OpenUIState(GurtTranslator.Instance);
    }
}