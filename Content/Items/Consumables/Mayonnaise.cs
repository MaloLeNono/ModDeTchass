using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables;

public class Mayonnaise : ModItem
{
    public override void SetStaticDefaults() => ItemID.Sets.DrinkParticleColors[Type] = [Color.White];
    
    public override void SetDefaults()
    {
        Item.width = 26;
        Item.width = 26;
        Item.useStyle = ItemUseStyleID.DrinkLiquid;
        Item.useAnimation = 15;
        Item.useTime = 15;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item3;
        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;
        Item.rare = ItemRarityID.Green;
        Item.value = Item.buyPrice(gold: 5);
    }

    public override bool? UseItem(Player player)
    {
        player.AddBuff(BuffID.WellFed3, 99999999);
        player.AddBuff(BuffID.Regeneration, 99999999);
        player.AddBuff(BuffID.ManaRegeneration, 99999999);
        player.AddBuff(BuffID.Spelunker,99999999);
        player.AddBuff(BuffID.Archery, 99999999);
        player.AddBuff(BuffID.Ironskin, 99999999);
        player.AddBuff(BuffID.Wrath, 99999999);
        player.AddBuff(BuffID.Rage, 99999999);
        player.AddBuff(BuffID.NightOwl, 99999999);
        player.AddBuff(BuffID.Lifeforce, 99999999);
        return true;
    }
}