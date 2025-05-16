using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Materials;

class GoldenTchass : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 30;
        Item.value = Item.buyPrice(silver: 80);
        Item.maxStack = Item.CommonMaxStack;
        Item.rare = ItemRarityID.Yellow;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<BouffeDeTchass>(5)
            .AddIngredient(ItemID.GoldBar, 1)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient<BouffeDeTchass>(5)
            .AddIngredient(ItemID.PlatinumBar, 1)
            .AddTile(TileID.Anvils)
            .Register();
    }
}