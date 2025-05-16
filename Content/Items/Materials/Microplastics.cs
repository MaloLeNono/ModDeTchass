using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Materials;

class Microplastics : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 29;
        Item.height = 24;
        Item.value = Item.buyPrice(copper: 10);
        Item.maxStack = Item.CommonMaxStack;
        Item.rare = ItemRarityID.Gray;
    }
}