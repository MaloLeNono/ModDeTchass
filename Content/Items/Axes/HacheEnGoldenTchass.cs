using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Axes;

class HacheEnGoldenTchass : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 36;
        Item.height = 32;
        Item.value = Item.buyPrice(gold: 1);
        Item.axe = 11; // 55 
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 6;
        Item.damage = 10;
        Item.rare = ItemRarityID.Yellow;
        Item.DamageType = DamageClass.Melee;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<GoldenTchass>(10)
            .AddIngredient(ItemID.Wood, 5)
            .AddTile(TileID.Anvils)
            .Register();
    }
}