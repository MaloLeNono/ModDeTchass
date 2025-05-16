using Microsoft.Xna.Framework;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Guns;

class GunDeTchass : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 36;
        Item.height = 22;
        Item.value = Item.buyPrice(gold: 1);
        Item.rare = ItemRarityID.Blue;
        Item.shoot = ProjectileID.PurificationPowder;
        Item.shootSpeed = 10f;
        Item.DamageType = DamageClass.Ranged;
        Item.damage = 1;
        Item.useTime = 5;
        Item.useAnimation = 5;
        Item.autoReuse = true;
        Item.UseSound = ModDeTchass.LudoEi;
        Item.knockBack = 0f;
        Item.noMelee = true;
        Item.useAmmo = AmmoID.Bullet;
        Item.useStyle = ItemUseStyleID.Shoot;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<BouffeDeTchass>(25)
            .AddIngredient(ItemID.IllegalGunParts, 2)
            .AddTile(TileID.Anvils)
            .Register();
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(0f, 4f);
    }
}