using ModDeTchass.Content.Tiles.Walls;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Tiles;

public class PlateformeDeTchass : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 14;
        Item.DefaultToPlaceableTile(ModContent.TileType<Content.Tiles.PlateformeDeTchass>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddIngredient<BriqueDeTchass>()
            .Register();
    }
}