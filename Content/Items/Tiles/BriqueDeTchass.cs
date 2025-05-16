using ModDeTchass.Content.Items.Tiles.Walls;
using Terraria.ID;
using Terraria.ModLoader;
using RawTchass = ModDeTchass.Content.Items.Materials.RawTchass;

namespace ModDeTchass.Content.Items.Tiles;

public class BriqueDeTchass : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;
        Item.DefaultToPlaceableTile(ModContent.TileType<Content.Tiles.BriqueDeTchass>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(5)
            .AddIngredient<RawTchass>()
            .AddTile(TileID.HeavyWorkBench)
            .Register();

        CreateRecipe()
            .AddIngredient<MurDeTchass>(4)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}