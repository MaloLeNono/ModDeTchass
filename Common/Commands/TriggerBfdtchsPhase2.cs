using System.Linq;
using ModDeTchass.Content.NPCs.Bosses;
using Steamworks;
using Terraria;
using Terraria.ModLoader;

namespace ModDeTchass.Common.Commands;

public class TriggerBfdtchsPhase2 : ModCommand
{
    public override CommandType Type => CommandType.Chat;
    public override string Command => "triggerbfdtchsphase2";
    public override string Description => "Triggers the second phase of B.F.D.T.C.H.S (Sets life to requirement)";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        if (!NPC.AnyNPCs(ModContent.NPCType<BFDTCHS>()) || SteamUser.GetSteamID().m_SteamID != 76561198068879376) 
            return;
        
        NPC bfdtchs = FindNPC();
        bfdtchs.life /= 2;
        bfdtchs.life -= 1;
    }
    
    private static NPC FindNPC()
    {
        return Main.npc.FirstOrDefault(npc => npc.type == ModContent.NPCType<BFDTCHS>());
    }
}