using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Pickaxes
{
    class PiocheEnGoldenTchass : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.buyPrice(silver: 45);
            Item.damage = 20;
            Item.knockBack = 7;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 14;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Yellow;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.pick = 55;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<GoldenTchass>(15)
                .AddIngredient(ItemID.Wood)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
