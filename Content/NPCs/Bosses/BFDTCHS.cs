using System;
using Microsoft.Xna.Framework;
using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Backgrounds;
using ModDeTchass.Content.BossBars;
using ModDeTchass.Content.Buffs;
using ModDeTchass.Content.Items.Guns;
using ModDeTchass.Content.Items.Materials;
using ModDeTchass.Content.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.NPCs.Bosses;

[AutoloadBossHead]
public class BFDTCHS : ModNPC
{
    private bool canResetTimer = true;
    private bool phase2;
    public bool Enraged;
    private int projectileChance = 5;
    private float speed = 7f;
    private bool nextMove;
    private int timer;
    private int projTimer = 6;
    private int shootTimer;
    private int moveTimer;
    private int rotation;

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
        NPC.DeathSound = Sounds.LudoEi;
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

    public override Color? GetAlpha(Color drawColor) => phase2 || Enraged ? Color.Red : Color.White;

    public override void AI()
    {
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
        {
            NPC.TargetClosest();
        }

        timer++;
        moveTimer++;
        shootTimer++;
        
        Main.bgStyle = ModContent.GetInstance<BfdtchsBack>().Slot;

        if (moveTimer == 1200 && !nextMove)
            nextMove = true;

        if (phase2)
            projTimer++;
        
        Player player = Main.player[NPC.target];
        Vector2 direction = NPC.DirectionTo(player.Center);
        IEntitySource source = NPC.GetSource_FromAI();
        
        if (player.dead)
        {
            NPC.velocity = NPC.DirectionFrom(player.Center) * 50f;
            NPC.EncourageDespawn(10);
            return;
        }

        if (Main.netMode != NetmodeID.MultiplayerClient && !Main.raining)
        {
            Main.StartRain();
            Main.SyncRain();
        }

        FireConstantProjectiles(direction, source);
        
        Move(player, direction);

        CheckEnraged(player);

        CheckSecondPhase();

        FireAngleProjectiles(direction, source);
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        if (!Main.dedServ)
            SoundEngine.PlaySound(Sounds.PiedsOursin, NPC.position);

        for (int i = 0; i < 4; i++)
        {
            Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.ShimmerSpark, Scale: 4);
        }

        FireRandomOnHit();
    }

    private void FireAngleProjectiles(Vector2 direction, IEntitySource source)
    {
        if (Main.netMode != NetmodeID.MultiplayerClient && phase2 && projTimer >= 8)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector2 newDir = direction.RotatedBy(MathHelper.ToRadians(rotation));
                Projectile.NewProjectile(source, NPC.Center, newDir * speed * 1.2f, ModContent.ProjectileType<NoHomingTchassProjectile>(), 400, 5);
                rotation += 90;
            }

            projTimer = 0;
            rotation += 45;
        }
    }

    private void FireConstantProjectiles(Vector2 direction, IEntitySource source)
    {
        if (Main.netMode != NetmodeID.MultiplayerClient && shootTimer == 300 && !phase2)
        {
            shootTimer = 0;
            Projectile.NewProjectile(source, NPC.Center, direction * speed * 1.7f, ModContent.ProjectileType<NoHomingTchassProjectile>(), 250, 5);
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
                SoundEngine.PlaySound(Sounds.Beuh, NPC.position);
            phase2 = true;
        }
    }

    private void CheckEnraged(Player player)
    {
        float distance = NPC.Distance(player.Center);
        
        if (distance > 1500 && timer >= 300 && !Enraged)
        {
            NPC.BossBar = ModContent.GetInstance<BfdtchsEnragedBossBar>();
            speed = 12f;
            Enraged = true;
            if (!Main.dedServ)
                SoundEngine.PlaySound(Sounds.Beuh, NPC.position);
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

    private void Move(Player player, Vector2 direction)
    {
        if (nextMove)
        {
            if (canResetTimer)
            {
                moveTimer = 0;
                canResetTimer = false;
            }

            if (!phase2)
            {
                Vector2 playerOffsetRight = player.Center + new Vector2(2000 - NPC.width / 2f, -NPC.height / 2f);
                Vector2 playerOffsetLeft = player.Center + new Vector2(-2000 / 4f - NPC.width / 2f, -NPC.height / 2f);
                
                NPC.position = Vector2.Lerp(NPC.position, NPC.position.Distance(playerOffsetRight) < NPC.position.Distance(playerOffsetLeft)
                    ? playerOffsetRight
                    : playerOffsetLeft, 0.2f);
            }
            else
            {
                float angle = Main.GameUpdateCount * 0.025f;
                Vector2 targetPos = player.Center + new Vector2(500f * MathF.Cos(angle), 500f * MathF.Sin(angle));

                NPC.Center = Vector2.Lerp(NPC.Center, targetPos, 0.2f);
            }

            NPC.velocity = player.velocity;

            if (moveTimer == 1200)
            {
                nextMove = false;
                canResetTimer = true;
                moveTimer = 0;
            }

            return;
        }
        
        NPC.velocity = direction * speed;
    }

    public override void OnKill()
    {
        NPC.SetEventFlagCleared(ref DownedBossSystem.downedBossDeTchass, -1);
        Main.bgStyle = 0;
        
        if (Main.netMode != NetmodeID.MultiplayerClient)
        {
            Main.StopRain();
            Main.SyncRain();
        }
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