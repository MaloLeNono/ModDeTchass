using Microsoft.Xna.Framework;
using ModDeTchass.Common.Systems;
using ModDeTchass.Content.BossBars;
using ModDeTchass.Content.Buffs;
using ModDeTchass.Content.Items.Guns;
using ModDeTchass.Content.Items.Materials;
using ModDeTchass.Content.Projectiles;
using SDL2;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.NPCs.Bosses;

[AutoloadBossHead]
class BFDTCHS : ModNPC
{
    bool phase2 = false;
    bool enraged = false;
    int projectileChance = 5;
    float speed = 7f;
    int timer;
    int projTimer = 6;
    int rotation = 0;

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
        NPC.damage = 150;
        NPC.defense = 0;
        NPC.lifeMax = 500000;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = ModDeTchass.LudoEi;
        NPC.knockBackResist = 0;
        NPC.aiStyle = -1;
        NPC.boss = true;
        NPC.noGravity = true;
        NPC.BossBar = ModContent.GetInstance<BfdtchsBossBar>();
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
        return phase2 || enraged ? Color.Red : Color.White;
    }

        
    public override void AI()
    {
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
        {
            NPC.TargetClosest();
        }

        timer++;

        if (phase2)
            projTimer++;
        
        Player player = Main.player[NPC.target];
        float distance = NPC.Distance(player.Center);
        Vector2 direction = NPC.DirectionTo(player.Center);
        NPC.velocity = direction * speed;

        if (player.dead)
        {
            NPC.velocity = NPC.DirectionFrom(player.Center) * 50;
            NPC.EncourageDespawn(10);
            return;
        }

        CheckEnraged(distance);

        CheckSecondPhase();

        FireAngleProjectiles(direction);
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        if (!Main.dedServ)
            SoundEngine.PlaySound(ModDeTchass.PiedsOursin, NPC.position);

        for (int i = 0; i < 4; i++)
        {
            Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.ShimmerSpark, Scale: 4);
        }

        FireRandomOnHit();
    }

    private void FireAngleProjectiles(Vector2 direction)
    {
        IEntitySource source = NPC.GetSource_FromAI();
        if (Main.netMode != NetmodeID.MultiplayerClient && phase2 && projTimer >= 6)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector2 newDir = direction.RotatedBy(MathHelper.ToRadians(rotation));
                Projectile.NewProjectile(source, NPC.Center, newDir * speed * 1.2f,
                    ModContent.ProjectileType<NoHomingTchassProjectile>(), 400, 5);
                rotation += 90;
            }

            projTimer = 0;
            rotation += 45;
        }
    }

    private void CheckSecondPhase()
    {
        if (NPC.life < NPC.lifeMax / 2 && !phase2)
        {
            NPC.netUpdate = true;
            NPC.HitSound = SoundID.NPCHit4;
            speed *= 1.2f;
            projectileChance = 2;
            if (!Main.dedServ)
                SoundEngine.PlaySound(ModDeTchass.Beuh, NPC.position);
            phase2 = true;
        }
    }

    private void CheckEnraged(float distance)
    {
        if (distance > 1500 && timer >= 300)
        {
            NPC.BossBar = ModContent.GetInstance<BfdtchsEnragedBossBar>();
            speed = 12f;
            enraged = true;
            if (!Main.dedServ)
                SoundEngine.PlaySound(ModDeTchass.Beuh, NPC.position);
        }
    }

    private void FireRandomOnHit()
    {
        Player player = Main.player[NPC.target];
        Vector2 direction = NPC.DirectionTo(player.Center);
        IEntitySource source = NPC.GetSource_FromAI();

        if (Main.netMode != NetmodeID.MultiplayerClient)
        {
            if (Main.rand.NextBool(projectileChance))
            {
                Projectile.NewProjectile(source, NPC.Center, direction, ModContent.ProjectileType<TchassProjectile>(), 300, 5);
            }

            if (!phase2)
                return;
            
            if (Main.rand.NextBool(projectileChance))
            {
                Projectile.NewProjectile(source, NPC.Center, direction * speed * 1.2f, ModContent.ProjectileType<NoHomingTchassProjectile>(), 400, 5);
            }
            
            if (Main.rand.NextBool(20))
            {
                Projectile.NewProjectile(source, NPC.Bottom, direction * speed * 1.3f, ModContent.ProjectileType<TchassProjectile>(), 300, 5);
                Projectile.NewProjectile(source, NPC.Top, direction * speed * 1.3f, ModContent.ProjectileType<TchassProjectile>(), 300, 5);
                Projectile.NewProjectile(source, NPC.Left, direction * speed * 1.3f, ModContent.ProjectileType<TchassProjectile>(), 300, 5);
                Projectile.NewProjectile(source, NPC.Right, direction * speed * 1.3f, ModContent.ProjectileType<TchassProjectile>(), 300, 5);
            }
        }
    }

    public override void OnKill()
    {
        NPC.SetEventFlagCleared(ref DownedBossSystem.downedBossDeTchass, -1);
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        target.AddBuff(ModContent.BuffType<Baladie>(), 18000);
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SuperTchass>(), 1, 20, 30));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<M61Vulcan>()));
        npcLoot.Add(ItemDropRule.Common(ItemID.PlatinumCoin, 1, 5, 10));
    }
}