using Microsoft.Xna.Framework;
using ModDeTchass.Common.Systems;
using Steamworks;
using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.NPCs.Bosses;

[AutoloadBossHead]
public class UnemploymentFinalBoss : ModNPC
{
    public override void SetStaticDefaults()
    {
        NPCID.Sets.MPAllowedEnemies[Type] = true;
        NPCID.Sets.BossBestiaryPriority.Add(Type);
    }

    public override void SetDefaults()
    {
        NPC.netAlways = true;
        NPC.width = 227;
        NPC.height = 294;
        NPC.damage = 999;
        NPC.defense = 999;
        NPC.lifeMax = 5000000;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = Sounds.LudoEi;
        NPC.knockBackResist = 0;
        NPC.aiStyle = -1;
        NPC.boss = true;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.SpawnWithHigherTime(30);
        NPC.npcSlots = 20f;
        if (!Main.dedServ)
        {
            Music = MusicLoader.GetMusicSlot(Mod, "Content/Sounds/Music/unemployed");
        }
    }

    public override void AI()
    {
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
        {
            NPC.TargetClosest();
        }
        
        Player player = Main.player[NPC.target];

        if (player.dead)
        {
            NPC.EncourageDespawn(20);
            NPC.velocity = NPC.DirectionFrom(player.Center) * 20f;
            return;
        }
        
        NPC.velocity = NPC.DirectionTo(player.Center) * 20f;
        NPC.rotation = NPC.AngleTo(player.Center);
    }

    public override Color? GetAlpha(Color drawColor)
    {
        return Color.White;
    }
}