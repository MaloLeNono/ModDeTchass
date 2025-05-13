using ModDeTchass.Content.Buffs;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables
{
    class CanOfInsects : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 36;
            Item.value = Item.buyPrice(silver: 2);
            Item.consumable = true;
            Item.UseSound = ModDeTchass.OursinEi;
            Item.maxStack = Item.CommonMaxStack;
            Item.useTurn = true;
            Item.rare = ItemRarityID.Gray;
            Item.buffType = ModContent.BuffType<Insectes>();
            Item.buffTime = 99999999;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Worm, 10)
                .AddIngredient<StockholmSyndrome>(3)
                .AddIngredient(ItemID.Bottle)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
