using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Materials
{
    class SuperTchass : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.buyPrice(gold: 20);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Expert;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BouffeDeTchass>(20)
                .AddIngredient(ItemID.HallowedBar, 20)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
