using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ModDeTchass.Common.Systems;
using ModDeTchass.Content.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Projectiles;

class TchassProjectile : ModProjectile
{
    bool canPlaySound = true;

    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void SetDefaults()
    {
        Projectile.width = 30;
        Projectile.height = 60;
        Projectile.aiStyle = -1;
        Projectile.friendly = false;
        Projectile.hostile = true;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.penetrate = 1;
        Projectile.timeLeft = Main.rand.Next(90, 150);
        Projectile.alpha = 0;
        Projectile.light = 1f;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        Projectile.extraUpdates = 1;
        AIType = ProjectileID.Bullet;
    }

    public override void AI()
    {
        if (!Main.dedServ && canPlaySound)
        {
            SoundEngine.PlaySound(Sounds.LudoEi, Projectile.position); // Placeholder
            canPlaySound = false;
        }

        Player player = Main.player[Player.FindClosest(Projectile.Center, Projectile.width, Projectile.height)];

        float speed = 7.5f;
        
        if (BFDTCHS.Enraged)
            speed = 15f;
        
        Vector2 direction = player.Center - Projectile.Center;
        direction.Normalize();
        Projectile.velocity = direction * speed;
        Projectile.rotation = Projectile.velocity.ToRotation();
    }

    public override bool PreDraw(ref Color lightColor)
    {
        Texture2D texture = TextureAssets.Projectile[Type].Value;

        Vector2 drawOrigin = new(texture.Width * 0.5f, Projectile.height * 0.5f);
        for (int k = Projectile.oldPos.Length - 1; k > 0; k--)
        {
            Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
            Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None);
        }

        return true;
    }

    public override void OnKill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        for (int i = 0; i < 5; i++)
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.ShimmerSpark, Scale: 2);
        }
    }
}