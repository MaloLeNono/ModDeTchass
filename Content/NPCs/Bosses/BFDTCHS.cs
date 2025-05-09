using Microsoft.Xna.Framework;
using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Items.Guns;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.NPCs.Bosses
{
    [AutoloadBossHead]
    class BFDTCHS : ModNPC
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
            NPC.lifeMax = 500000;
            NPC.HitSound = ModDeTchass.PiedsOursin;
            NPC.DeathSound = ModDeTchass.LudoEi;
            NPC.knockBackResist = 0;
            NPC.aiStyle = -1;
            NPC.boss = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.SpawnWithHigherTime(10);
            NPC.npcSlots = 10f;
            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Content/Sounds/Music/bfdtchsSong");
            }
        }

        public override Color? GetAlpha(Color drawColor)
        {
            return Color.White;
        }

        public override void AI()
        {
            Main.dayTime = false;

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

            Vector2 direction = player.Center - NPC.Center;
            direction.Normalize();
            float speed = 7f;

            NPC.velocity = direction * speed;
        }

        public override void OnHitByProjectile(Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 4; i++)
            {
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.ShimmerSpark, Scale: 4);
            }
        }

        public override void OnHitByItem(Player player, Item item, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 4; i++)
            {
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.ShimmerSpark, Scale: 4);
            }
        }

        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedBossDeTchass, -1);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SuperTchass>(), 1, 20, 30));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<M61Vulcan>(), 1, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.PlatinumCoin, 1, 5, 10));
        }
    }
}