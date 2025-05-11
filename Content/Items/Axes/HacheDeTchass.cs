using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Axes
{
    class HacheDeTchass : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 30;
            Item.value = Item.buyPrice(gold: 1);
            Item.axe = 1; // 5
            Item.useTime = 1;
            Item.useAnimation = 2;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 99;
            Item.damage = 1;
            Item.rare = ItemRarityID.Blue;
            Item.DamageType = DamageClass.Melee;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BouffeDeTchass>(30)
                .AddIngredient(ItemID.Wood, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
