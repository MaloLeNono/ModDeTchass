using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables;

class GlennQuagmire : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 27;
        Item.height = 29;
        Item.value = Item.buyPrice(gold: 5);
        Item.consumable = true;
        Item.UseSound = Sounds.GlennQuagmire;
        Item.maxStack = Item.CommonMaxStack;
        Item.useTurn = true;
        Item.rare = ItemRarityID.Blue;
        Item.useAnimation = 15;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.HoldUp;
    }

    public override bool? UseItem(Player player) => true;

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<RawTchass>(5)
            .AddIngredient<BouffeDeTchass>(5)
            .AddIngredient<GoldenTchass>(5)
            .AddIngredient<SuperTchass>(5)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}