using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Materials
{
    class RawTchass : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.buyPrice(silver: 15);
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RawTchass>());
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
        }
    }
}
