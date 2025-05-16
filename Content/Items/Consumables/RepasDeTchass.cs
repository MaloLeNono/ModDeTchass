using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables;

class RepasDeTchass : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.IsFood[Type] = true;
    }

    public override void SetDefaults()
    {
        Item.DefaultToFood(30, 30, BuffID.WellFed3, 36000);
        Item.rare = ItemRarityID.Green;
        Item.value = Item.buyPrice(silver: 20);
    }

    public override void OnConsumeItem(Player player)
    {
        player.AddBuff(BuffID.Battle, 3600);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<BouffeDeTchass>(10)
            .AddTile(TileID.CookingPots)
            .Register();
    }
}