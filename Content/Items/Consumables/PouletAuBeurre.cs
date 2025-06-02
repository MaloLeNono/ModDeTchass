using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables;

public class PouletAuBeurre : ModItem
{
    public override void SetStaticDefaults() => ItemID.Sets.IsFood[Type] = true;
    
    public override void SetDefaults()
    {
        Item.DefaultToFood(39, 39, BuffID.WellFed3, 36000);
        Item.rare = ItemRarityID.Orange;
        Item.value = Item.buyPrice(gold: 2);
    }
}