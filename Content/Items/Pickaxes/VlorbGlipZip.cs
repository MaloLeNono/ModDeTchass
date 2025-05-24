using Microsoft.Xna.Framework;
using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Pickaxes;

public class VlorbGlipZip : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 30;
        Item.value = Item.buyPrice(gold: 7);
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 8;
        Item.useAnimation = 15;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee;
        Item.useTurn = true;
        Item.damage = 37;
        Item.knockBack = 4;
        Item.pick = 190;
        Item.rare = ItemRarityID.Green;
        Item.UseSound = Sounds.Ai;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        Dust.NewDust(player.position, player.width, player.height, DustID.GreenFairy, Scale: 0.7f);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<AlienTchass>(12)
            .AddIngredient<SuperTchass>(2)
            .AddIngredient(ItemID.Wood, 4)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}