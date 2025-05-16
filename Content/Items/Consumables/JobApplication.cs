using ModDeTchass.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables;

public class JobApplication : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 44;
        Item.scale = 0.7f;
        Item.consumable = true;
        Item.value = Item.buyPrice(silver: 5);
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useTurn = true;
        Item.rare = ItemRarityID.Expert;
        Item.UseSound = ModDeTchass.LudoDrogue;
        Item.maxStack = Item.CommonMaxStack;
        Item.buffType = ModContent.BuffType<Employed>();
        Item.buffTime = 99999999;
    }
}