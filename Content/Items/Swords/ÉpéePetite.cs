using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Swords;

public class ÉpéePetite : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 12;
        Item.height = 12;
        Item.value = Item.buyPrice(copper: 1);
        Item.damage = 2;
        Item.knockBack = 0;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.UseSound = SoundID.Item1;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = false;
        Item.rare = ItemRarityID.Orange;
        Item.useTurn = true;
        Item.DamageType = DamageClass.MeleeNoSpeed;
    }
    
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.IronBar)
            .AddTile(TileID.Anvils)
            .Register();
    }
}