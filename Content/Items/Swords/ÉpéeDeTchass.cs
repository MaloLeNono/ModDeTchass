using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Swords
{
    class ÉpéeDeTchass : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.value = Item.buyPrice(gold: 2);
            Item.damage = 1;
            Item.knockBack = 0;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 1;
            Item.useAnimation = 2;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BouffeDeTchass>(20)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
