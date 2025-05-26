using ModDeTchass.Common.Systems;
using Steamworks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Common.Commands;

public class AllowBfdtchsSpawn : ModCommand
{
    public override CommandType Type => CommandType.Chat;
    public override string Command => "allowbfdtchsspawn";
    public override string Description => "Meets the conditions to spawn B.F.D.T.C.H.S (You might not want to do this on an actual world)";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        if (SteamUser.GetSteamID().m_SteamID != 76561198068879376)
            return;
        
        Main.hardMode = true;

        NPC.downedMechBoss1 = true;
        NPC.downedMechBoss2 = true;
        NPC.downedMechBoss3 = true;

        DownedBossSystem.downedBossDeTchass = true;
        
        if (Main.netMode == NetmodeID.Server)
            NetMessage.SendData(MessageID.WorldData);
    }
}