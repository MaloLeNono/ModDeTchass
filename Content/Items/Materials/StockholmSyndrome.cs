using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Materials
{
    class StockholmSyndrome : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 0;
            Item.rare = ItemRarityID.Gray;
            Item.maxStack = Item.CommonMaxStack;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BuilderPotion)
                .AddIngredient(ItemID.FlinxFur)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
