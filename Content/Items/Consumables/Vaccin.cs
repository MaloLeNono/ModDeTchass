using ModDeTchass.Content.Buffs;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables
{
    class Vaccin : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 46;
            Item.value = Item.buyPrice(silver: 2);
            Item.maxStack = Item.CommonMaxStack;
            Item.UseSound = SoundID.NPCHit1;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.useTurn = true;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Autism>();
            Item.buffTime = 1632000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient<BouffeDeTchass>(5)
                .AddTile(TileID.AlchemyTable)
                .Register();
        }
    }
}
