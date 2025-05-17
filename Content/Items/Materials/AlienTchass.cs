using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Materials;

public class AlienTchass : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 30;
        Item.value = Item.buyPrice(gold: 10);
        Item.maxStack = Item.CommonMaxStack;
        Item.rare = ItemRarityID.Green;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.MartianConduitPlating, 2)
            .AddIngredient<BouffeDeTchass>(1)
            .AddTile(TileID.LihzahrdFurnace)
            .Register();
    }
}