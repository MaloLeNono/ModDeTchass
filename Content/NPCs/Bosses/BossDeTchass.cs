using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Items.Consumables;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.NPCs.Bosses
{
    [AutoloadBossHead]
    class BossDeTchass : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);
        }

        public override void SetDefaults()
        {
            NPC.netAlways = true;
            NPC.width = 450;
            NPC.height = 377;
            NPC.damage = 9999;
            NPC.defense = 0;
            NPC.lifeMax = 600;
            NPC.HitSound = ModDeTchass.PiedsOursin;
            NPC.DeathSound = ModDeTchass.LudoEi;
            NPC.knockBackResist = 0;
            NPC.aiStyle = -1;
            NPC.boss = true;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
            NPC.SpawnWithHigherTime(10);
            NPC.npcSlots = 10f;
            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Content/Sounds/Music/BossDeTchassSong");
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
                NPC.noTileCollide = true;
                NPC.velocity.Y -= 50;
                NPC.EncourageDespawn(10);
                return;
            }
        }

        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedBossDeTchass, -1);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RawTchass>(), 1, 50, 70));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WhiteMonster>(), 1, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 10, 20));
        }
    }
}
