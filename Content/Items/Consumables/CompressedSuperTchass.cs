using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Items.Materials;
using ModDeTchass.Content.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables
{
    class CompressedSuperTchass : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 0;
            Item.height = 0;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(gold: 60);
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<BFDTCHS>()) && Condition.Hardmode.IsMet() && Condition.DownedMechBossAll.IsMet() && DownedBossSystem.downedBossDeTchass;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(ModDeTchass.LudoLaugh);

                int type = ModContent.NPCType<BFDTCHS>();

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
                .AddIngredient<SuperTchass>(30)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
