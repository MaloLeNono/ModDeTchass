using ModDeTchass.Content.Buffs;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables;

class Prime : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 9;
        Item.height = 25;
        Item.value = Item.buyPrice(silver: 2, copper: 99);
        Item.consumable = true;
        Item.UseSound = SoundID.Item3;
        Item.useStyle = ItemUseStyleID.DrinkLiquid;
        Item.useTurn = true;
        Item.buffType = ModContent.BuffType<Cancer>();
        Item.buffTime = 99999999;
        Item.maxStack = Item.CommonMaxStack;
        Item.rare = ItemRarityID.Cyan;
        Item.useTime = 15;
        Item.useAnimation = 15;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<Microplastics>(5)
            .AddIngredient(ItemID.Deathweed)
            .AddIngredient(ItemID.BottledWater)
            .AddTile(TileID.AlchemyTable)
            .Register();
    }
}