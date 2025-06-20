﻿using Microsoft.Xna.Framework;
using ModDeTchass.Common.Systems;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Guns;

class M61Vulcan : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 41;
        Item.height = 11;
        Item.scale = 2f;
        Item.value = Item.buyPrice(gold: 5);
        Item.rare = ItemRarityID.Expert;
        Item.shoot = ProjectileID.PurificationPowder;
        Item.shootSpeed = 15f;
        Item.DamageType = DamageClass.Ranged;
        Item.damage = 300;
        Item.useTime = 2;
        Item.useAnimation = 2;
        Item.autoReuse = true;
        Item.UseSound = Sounds.M61Fire;
        Item.knockBack = 0f;
        Item.noMelee = true;
        Item.useAmmo = AmmoID.Bullet;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.channel = true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Vector2 recoil = -Vector2.Normalize(velocity) * 2;
        player.velocity += recoil;
        return true;
    }

    public override Vector2? HoldoutOffset() => new Vector2(-1f, 0f);
}

class F16FighterJet : ModPlayer
{
    public bool wasFiring;

    public override void PostUpdate()
    {
        bool isFiring = Player.channel && Player.HeldItem.type == ModContent.ItemType<M61Vulcan>();

        if (wasFiring && !isFiring)
        {
            if (!Main.dedServ)
                SoundEngine.PlaySound(Sounds.StrafeEnd, Player.position);
        }

        wasFiring = isFiring;
    }
}