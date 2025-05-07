using Microsoft.Xna.Framework;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Hammers
{
    class BFDTCHammer : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 54;
            Item.value = Item.buyPrice(gold: 1);
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.DamageType = DamageClass.Melee;
            Item.hammer = 100;
            Item.damage = 80;
            Item.knockBack = 9;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Expert;
            Item.useStyle = ItemUseStyleID.Swing;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<SuperTchass>(15)
                .AddIngredient(ItemID.Wood, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
