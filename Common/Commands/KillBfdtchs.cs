using ModDeTchass.Content.NPCs.Bosses;
using Steamworks;
using Terraria;
using Terraria.ModLoader;

namespace ModDeTchass.Common.Commands;

public class KillBfdtchs : ModCommand
{
    public override CommandType Type => CommandType.Chat;
    public override string Command => "killbfdtchs";
    public override string Description => "Kills B.F.D.T.C.H.S";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        if (SteamUser.GetSteamID().m_SteamID != 76561198068879376)
            return;
        
        NPC bfdtchs = FindNPC();
        bfdtchs.StrikeInstantKill();
    }
    
    private static NPC FindNPC()
    {
        for (int i = 0; i < Main.maxNPCs; i++)
        {
            NPC npc = Main.npc[i];
            if (npc.type == ModContent.NPCType<BFDTCHS>())
                return npc;
        }

        return null;
    }
}