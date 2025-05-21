using Microsoft.Xna.Framework;
using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Axes;

public class VorpGorpBlorpLorp : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 34;
        Item.value = Item.buyPrice(gold: 1);
        Item.axe = 20; // 100
        Item.useTime = 8;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 4.5f;
        Item.damage = 45;
        Item.rare = ItemRarityID.Green;
        Item.DamageType = DamageClass.Melee;
        Item.UseSound = Sounds.Ai;
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
            .AddIngredient<AlienTchass>(9)
            .AddIngredient(ItemID.Wood, 4)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}