using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Hammers;

class MarteauEnGoldenTchass : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 40;
        Item.value = Item.buyPrice(silver: 25);
        Item.hammer = 55;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 6;
        Item.rare = ItemRarityID.Yellow;
        Item.damage = 10;
        Item.DamageType = DamageClass.Melee;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<GoldenTchass>(15)
            .AddIngredient(ItemID.Wood, 5)
            .AddTile(TileID.Anvils)
            .Register();
    }
}