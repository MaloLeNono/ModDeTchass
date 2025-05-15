using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Swords;

public class ÉpéeGrosse : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 100;
        Item.height = 100;
        Item.scale = 6;
        Item.value = Item.buyPrice(gold: 10);
        Item.damage = 200;
        Item.knockBack = 20;
        Item.useTime = 90;
        Item.useAnimation = 90;
        Item.UseSound = SoundID.Item1;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = false;
        Item.rare = ItemRarityID.Orange;
        Item.DamageType = DamageClass.Melee;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Wood, 50)
            .AddIngredient(ItemID.IronBar, 100)
            .AddTile(TileID.Anvils)
            .Register();
    }
}