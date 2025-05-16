using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables
{
    class WhiteMonster : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.DrinkParticleColors[Type] = [
                new Color(255, 255, 255),
                new Color(150, 150, 150),
                new Color(70, 70, 70)
            ];
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.width = 32;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 2);
            Item.buffType = BuffID.NightOwl;
            Item.buffTime = 72000;
        }
    }
}
