﻿using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Items.Materials;
using ModDeTchass.Content.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables;

class SuspiciousLookingTchass : ModItem
{
    public override void SetStaticDefaults() => ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;

    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 30;
        Item.maxStack = Item.CommonMaxStack;
        Item.value = Item.buyPrice(gold: 1, silver: 50);
        Item.rare = ItemRarityID.Blue;
        Item.useAnimation = 30;
        Item.useTime = 30;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.consumable = true;
    }

    public override bool CanUseItem(Player player) => !NPC.AnyNPCs(ModContent.NPCType<BossDeTchass>());

    public override bool? UseItem(Player player)
    {
        if (player.whoAmI == Main.myPlayer)
        {
            SoundEngine.PlaySound(Sounds.LudoLaugh);

            int type = ModContent.NPCType<BossDeTchass>();

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, type);
            }
            else
            {
                NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
            }
        }

        return true;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<BouffeDeTchass>(15)
            .AddIngredient<RepasDeTchass>()
            .AddTile(TileID.DemonAltar)
            .Register();
    }
}