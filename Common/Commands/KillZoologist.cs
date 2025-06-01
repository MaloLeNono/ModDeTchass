using System.Linq;
using Steamworks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Common.Commands;

public class KillZoologist : ModCommand
{
    public override CommandType Type => CommandType.Chat;
    public override string Command => "killzoologist";
    public override string Description => "Kills the Zoologist";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        if (SteamUser.GetSteamID().m_SteamID != 76561198068879376)
            return;

        NPC zoologist = FindZoologist();
        zoologist.StrikeInstantKill();
    }

    private static NPC FindZoologist()
    {
        return Main.npc.FirstOrDefault(npc => npc.type == NPCID.BestiaryGirl);
    }
}