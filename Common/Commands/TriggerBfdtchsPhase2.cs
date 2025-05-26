using ModDeTchass.Content.NPCs.Bosses;
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
        if (!NPC.AnyNPCs(ModContent.NPCType<BFDTCHS>())) 
            return;
        
        NPC bfdtchs = FindNPC();
        bfdtchs.life /= 2;
        bfdtchs.life -= 1;
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