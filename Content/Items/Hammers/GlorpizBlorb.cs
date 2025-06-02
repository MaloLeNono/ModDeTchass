using Microsoft.Xna.Framework;
using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Hammers;

public class GlorpizBlorb : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 40;
        Item.value = Item.buyPrice(gold: 9);
        Item.hammer = 95;
        Item.useTime = 25;
        Item.rare = ItemRarityID.Green;
        Item.useAnimation = 25;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 7;
        Item.damage = 42;
        Item.DamageType = DamageClass.Melee;
        Item.UseSound = Sounds.Ai;
        Item.autoReuse = true;
        Item.useTurn = true;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox) => Dust.NewDust(player.position, player.width, player.height, DustID.GreenFairy, Scale: 0.7f);

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<AlienTchass>(10)
            .AddIngredient<SuperTchass>(2)
            .AddIngredient(ItemID.Wood, 4)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}