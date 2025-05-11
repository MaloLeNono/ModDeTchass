using ModDeTchass.Content.Items.Materials;
using ModDeTchass.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Drills
{
    class DrillDeTchass : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.IsDrill[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 18;
            Item.damage = 60;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.knockBack = 0.5f;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item23;
            Item.shoot = ModContent.ProjectileType<DrillDeTchassProjectile>();
            Item.shootSpeed = 32f;
            Item.rare = ItemRarityID.Blue;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.channel = true;

            Item.tileBoost = 5;
            Item.pick = 1;
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
