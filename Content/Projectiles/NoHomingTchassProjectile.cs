using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Projectiles;

class NoHomingTchassProjectile : ModProjectile
{
    bool canPlaySound = true;

    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void SetDefaults()
    {
        Projectile.width = 30;
        Projectile.height = 30;
        Projectile.aiStyle = 1;
        Projectile.friendly = false;
        Projectile.hostile = true;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.penetrate = 1;
        Projectile.timeLeft = 300;
        Projectile.alpha = 0;
        Projectile.light = 1f;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        Projectile.extraUpdates = 2;
        AIType = ProjectileID.Bullet;
    }

    public override void AI()
    {
        if (!Main.dedServ && canPlaySound)
        {
            SoundEngine.PlaySound(ModDeTchass.OursinEi, Projectile.position);
            canPlaySound = false;
        }
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
        Collision.TileCollision(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.ShimmerSpark, Scale: 2);
        SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
    }
}