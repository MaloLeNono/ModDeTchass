using Microsoft.Xna.Framework;
using ModDeTchass.Content.Items.Materials;
using ModDeTchass.Content.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Swords;

public class ZipGlorpVorp : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 0;
        Item.height = 0;
        Item.value = Item.buyPrice(gold: 20);
        Item.damage = 120;
        Item.knockBack = 5;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 18;
        Item.shoot = ModContent.ProjectileType<AlienProjectile>();
        Item.shootSpeed = 12f;
        Item.useAnimation = 18;
        Item.UseSound = ModDeTchass.Ai;
        Item.rare = ItemRarityID.Green;
        Item.DamageType = DamageClass.Melee;
        Item.autoReuse = true;
        Item.useTurn = true;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        Dust.NewDust(player.position, player.width, player.height, DustID.GreenFairy, Scale: 0.7f);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<AlienTchass>(15)
            .AddIngredient<SuperTchass>(2)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}