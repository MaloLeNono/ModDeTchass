using Microsoft.Xna.Framework;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables;

class PotionDeTchass : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.DrinkParticleColors[Type] = [
            new Color(242, 197, 92),
            new Color(150, 117, 38),
            new Color(71, 55, 18)
        ];
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.width = 30;
        Item.useStyle = ItemUseStyleID.DrinkLiquid;
        Item.useAnimation = 15;
        Item.useTime = 15;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item3;
        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;
        Item.rare = ItemRarityID.Green;
        Item.value = Item.buyPrice(gold: 2);
        Item.buffType = BuffID.Slow;
        Item.buffTime = 13800;
    }

    public override void OnConsumeItem(Player player)
    {
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<RawTchass>(1)
            .AddIngredient(ItemID.Mushroom, 1)
            .AddIngredient(ItemID.BottledWater)
            .AddTile(TileID.Tables)
            .AddTile(TileID.Bottles)
            .Register();
    }
}