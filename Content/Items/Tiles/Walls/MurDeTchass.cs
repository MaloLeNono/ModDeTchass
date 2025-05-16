using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Tiles.Walls;

public class MurDeTchass : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Tiles.Walls.MurDeTchass>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
            .AddIngredient<BriqueDeTchass>()
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}