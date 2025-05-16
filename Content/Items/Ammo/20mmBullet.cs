using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Ammo;

class _20mmBullet : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 14;
        Item.height = 48;
        Item.DamageType = DamageClass.Ranged;
        Item.damage = 95;
        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;
        Item.knockBack = 1f;
        Item.value = Item.buyPrice(silver: 5);
        Item.rare = ItemRarityID.Cyan;
        Item.shoot = ModContent.ProjectileType<Projectiles._20mmBullet>();
        Item.ammo = AmmoID.Bullet;
    }

    public override void AddRecipes()
    {
        CreateRecipe(50)
            .AddIngredient(ItemID.EmptyBullet, 50)
            .AddIngredient<SuperTchass>(1)
            .AddTile(TileID.Anvils)
            .Register();
    }
}