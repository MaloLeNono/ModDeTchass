using Microsoft.Xna.Framework;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Pickaxes;

class SuperPitchass : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.value = Item.buyPrice(gold: 1);
        Item.pick = 220;
        Item.useTime = 5;
        Item.useAnimation = 5;
        Item.useTurn = true;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 5;
        Item.damage = 50;
        Item.DamageType = DamageClass.Melee;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.rare = ItemRarityID.Expert;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<SuperTchass>(20)
            .AddIngredient(ItemID.Wood, 10)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}