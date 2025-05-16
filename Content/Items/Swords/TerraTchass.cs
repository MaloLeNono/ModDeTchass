using Microsoft.Xna.Framework;
using ModDeTchass.Content.Items.Materials;
using ModDeTchass.Content.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Swords;

class TerraTchass : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 46;
        Item.height = 54;
        Item.value = Item.buyPrice(gold: 50);
        Item.damage = 250;
        Item.knockBack = 7;
        Item.useTime = 8;
        Item.useAnimation = 8;
        Item.rare = ItemRarityID.Expert;
        Item.DamageType = DamageClass.Melee;
        Item.UseSound = SoundID.Item1;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.shoot = ModContent.ProjectileType<TerraTchassProjectile>();
        Item.shootSpeed = 5;
        Item.autoReuse = true;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (!Main.dedServ)
            SoundEngine.PlaySound(ModDeTchass.LudoDrogue);
        return true;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<SuperTchass>(20)
            .AddIngredient(ItemID.ShroomiteBar, 10)
            .AddIngredient(ItemID.ChlorophyteBar, 10)
            .AddIngredient(ItemID.BrokenHeroSword)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}