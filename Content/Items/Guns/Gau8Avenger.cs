using Microsoft.Xna.Framework;
using ModDeTchass.Common.Systems;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Guns;

public class Gau8Avenger : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 55;
        Item.height = 24;
        Item.scale = 1.8f;
        Item.value = Item.buyPrice(gold: 10);
        Item.rare = ItemRarityID.Expert;
        Item.shoot = ProjectileID.PurificationPowder;
        Item.shootSpeed = 16f;
        Item.DamageType = DamageClass.Ranged;
        Item.damage = 350;
        Item.useTime = 2;
        Item.useAnimation = 2;
        Item.autoReuse = true;
        Item.UseSound = Sounds.Gau8Fire;
        Item.knockBack = 0f;
        Item.noMelee = true;
        Item.useAmmo = AmmoID.Bullet;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.channel = true;
    }
    
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Vector2 recoil = -Vector2.Normalize(velocity) * 2;
        player.velocity += recoil;
        return true;
    }

    public override Vector2? HoldoutOffset() => new Vector2(-1f, 12f);

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<M61Vulcan>(2)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}

class A10AttackJet : ModPlayer
{
    public bool wasFiring;

    public override void PostUpdate()
    {
        bool isFiring = Player.channel && Player.HeldItem.type == ModContent.ItemType<Gau8Avenger>();

        if (wasFiring && !isFiring)
        {
            if (!Main.dedServ)
                SoundEngine.PlaySound(Sounds.StrafeEndGau8, Player.position);
        }

        wasFiring = isFiring;
    }
}