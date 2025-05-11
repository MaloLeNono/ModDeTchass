using ModDeTchass.Common.Systems;
using ModDeTchass.Content.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Materials
{
    class BouffeDeTchass : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.buyPrice(silver: 50);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<RawTchass>(4)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
